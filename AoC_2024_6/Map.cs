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
			var returnVal = 0;

			return returnVal;
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
