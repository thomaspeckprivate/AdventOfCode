namespace AoC_2024_1
{
	public class LeftRightList
	{
		private long[] Left { get; }

		private long[] Right { get; }

		public LeftRightList(string data)
		{
			string[] splitData = data.Split(Environment.NewLine);

			var leftList = new List<long>();
			var rightList = new List<long>();

			foreach (var row in splitData)
			{
				string[] listData = row.Split("   ");
				leftList.Add(long.Parse(listData[0]));
				rightList.Add(long.Parse(listData[1]));
			}
			leftList.Sort();
			rightList.Sort();

			Left = leftList.ToArray();
			Right = rightList.ToArray();
		}

		public long GetDifference()
		{
			var difference = 0L;
			for (int i = 0; i < Left.Length; i++)
			{
				difference += Math.Abs(Left[i] - Right[i]);
			}
			return difference;
		}
	}
}
