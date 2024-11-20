namespace AoC_2023_3
{
	public static class Helper
	{
		public static int SumPartNumber(List<int> adjacentPos, string line)
		{
			var newAdjacentPos = new List<int>();
			var objects = line.Split(".");
			char previousCharacter = '.';
			int index = 0;
			for (int i = 0; i < objects.Length; i++)
			{
				var minIndex = index;
				var maxIndex = Math.Max(objects[i].Length - 1, index);
				if (int.TryParse(objects[i], out var number))
				{

				}

				index++;
			}

			return 0;
		}
	}
}
