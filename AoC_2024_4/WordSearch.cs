namespace AoC_2024_4
{
	public class WordSearch
	{
		public IReadOnlyList<char[]> Grid { get; }
		//public IReadOnlyList<Position> StartPositions { get; }

		public long XmasCount = 0;

		public WordSearch(string data)
		{
			var grid = new List<char[]>();
			var splitData = data.Split(Environment.NewLine);
			for (int i = 0; i < splitData.Length; i++)
			{
				var charArray = splitData[i].ToCharArray();
				grid.Add(charArray);
				for (int j = 0; j < charArray.Length; j++)
				{
					switch (charArray[j])
					{
						case 'X':
							CheckBackwards(j, i, false, grid);
							CheckUp(j, i, false, grid);
							CheckDiagonal(j, i, false, grid);
							break;
						case 'S':
							CheckBackwards(j, i, true, grid);
							CheckUp(j, i, true, grid);
							CheckDiagonal(j, i, true, grid);
							break;
					}
				}
			}
			Grid = grid;
		}

		public long CountXmasAmount()
		{
			return XmasCount;
		}

		private void CheckBackwards(int x, int y, bool isBackwards, List<char[]> grid)
		{
			if (x < 3)
			{
				return;
			}

			if (!isBackwards)
			{
				XmasCount += grid[y][x - 1] == 'M' && grid[y][x - 2] == 'A' && grid[y][x - 3] == 'S' ? 1 : 0;
			}
			else
			{
				XmasCount += grid[y][x - 1] == 'A' && grid[y][x - 2] == 'M' && grid[y][x - 3] == 'X' ? 1 : 0;
			}
		}

		private void CheckUp(int x, int y, bool isBackwards, List<char[]> grid)
		{
			if (y < 3)
			{
				return;
			}

			if (!isBackwards)
			{
				XmasCount += grid[y - 1][x] == 'M' && grid[y - 2][x] == 'A' && grid[y - 3][x] == 'S' ? 1 : 0;
			}
			else
			{
				XmasCount += grid[y - 1][x] == 'A' && grid[y - 2][x] == 'M' && grid[y - 3][x] == 'X' ? 1 : 0;
			}
		}

		private void CheckDiagonal(int x, int y, bool isBackwards, List<char[]> grid)
		{
			if (y < 3)
			{
				return;
			}

			if (!isBackwards)
			{
				if (x >= 3)
				{
					XmasCount += grid[y - 1][x - 1] == 'M' && grid[y - 2][x - 2] == 'A' && grid[y - 3][x - 3] == 'S' ? 1 : 0;
				}

				if (x + 3 < grid[0].Length)
				{
					XmasCount += grid[y - 1][x + 1] == 'M' && grid[y - 2][x + 2] == 'A' && grid[y - 3][x + 3] == 'S' ? 1 : 0;
				}
			}
			else
			{
				if (x >= 3)
				{
					XmasCount += grid[y - 1][x - 1] == 'A' && grid[y - 2][x - 2] == 'M' && grid[y - 3][x - 3] == 'X' ? 1 : 0;
				}

				if (x + 3 < grid[0].Length)
				{
					XmasCount += grid[y - 1][x + 1] == 'A' && grid[y - 2][x + 2] == 'M' && grid[y - 3][x + 3] == 'X' ? 1 : 0;
				}
			}
		}

		//public sealed record Position(long x, long y, bool isBackwards);
	}
}
