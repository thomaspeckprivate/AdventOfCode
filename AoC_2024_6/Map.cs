namespace AoC_2024_6
{
	public class Map
	{
		private char[][] MappedArea;
		private Guard Guard;

		public Map(string data)
		{
			var splitData = data.Split(Environment.NewLine);
			var mappedArea = splitData.ToArray();

			var guardX = -1;
			var guardY = 0;
			for (; guardY < mappedArea.Length; guardY++)
			{
				guardX = mappedArea[guardY].IndexOfAny(new char[] { 'V', '>', '<', '^' });
				if (guardX >= 0)
				{
					break;
				}
			}

			MappedArea = mappedArea.Select(x => x.ToCharArray()).ToArray();
			Guard = new Guard(guardX, guardY, Guard.GetGuardDirection(mappedArea[guardY][guardX]), mappedArea.First().Length - 1, mappedArea.Length - 1);
		}

		public long GetGuardVisitedPositions(out List<Position> visitedPositions, char[][]? mappedArea = null)
		{
			mappedArea = mappedArea ?? MappedArea;
			visitedPositions = new List<Position>() { new Position(Guard.X, Guard.Y, Guard.Direction) };
			while (Guard.InMappedArea)
			{
				IncrementTime(mappedArea, out var position);

				if (visitedPositions.Contains(position))
				{
					return 0;
				}
				visitedPositions.Add(position);
			}

			var returnVal = 0;
			foreach (var hallway in mappedArea)
			{
				returnVal += hallway.Count(x => x == 'X');
			}

			return returnVal;
		}

		public long GetNumberOfValidObjectPositions()
		{
			char[][] newMap = new char[MappedArea.Length][];
			var mappedRowLength = MappedArea.First().Length;
			for (int i = 0; i < MappedArea.Length; i++)
			{
				newMap[i] = new char[mappedRowLength];
				Array.Copy(MappedArea[i], newMap[i], mappedRowLength);
			}
			GetGuardVisitedPositions(out var visitedPositions, newMap);
			visitedPositions.RemoveAt(visitedPositions.Count - 1);
			AbsolutePosition invalidPosition = new AbsolutePosition(visitedPositions.First().x, visitedPositions.First().y);
			var positionsToVisit = new HashSet<AbsolutePosition>();
			foreach (var position in visitedPositions)
			{
				var absPos = new AbsolutePosition(position.x, position.y);

				if (invalidPosition != absPos)
				{
					positionsToVisit.Add(absPos);
				}
			}
			Console.WriteLine(positionsToVisit.RemoveWhere(x => x.y < 0 || x.x < 0 || x.y >= MappedArea.Length || x.x >= MappedArea.First().Length));

			var validObjects = 0;

			foreach (var position in positionsToVisit)
			{

				for (int k = 0; k < MappedArea.Length; k++)
				{
					Array.Copy(MappedArea[k], newMap[k], mappedRowLength);
				}

				newMap[position.y][position.x] = 'O';

				Guard.ResetGuard();
				if (GetGuardVisitedPositions(out var _, newMap) == 0)
				{
					//foreach (var array in newMap)
					//{
					//	Console.WriteLine(array);
					//}
					//Console.WriteLine();
					validObjects++;
					Console.WriteLine($"Row: {position.y}, Column {position.x}");
				}
			}

			return validObjects;
		}

		private void IncrementTime(char[][] mappedArea, out Position nextPosition)
		{
			do
			{
				nextPosition = Guard.GetNextPosition();
				if (nextPosition.y < 0 || nextPosition.y >= mappedArea.Length || nextPosition.x < 0 || nextPosition.x >= mappedArea.First().Length || !(mappedArea[nextPosition.y][nextPosition.x] == '#' || mappedArea[nextPosition.y][nextPosition.x] == 'O'))
				{
					break;
				}
				Guard.SetNextDirection();
			} while (true);

			mappedArea[Guard.Y][Guard.X] = 'X';
			Guard.Move(nextPosition);
		}
	}
}
