namespace AoC_2023_3
{
	public static class Helper
	{
		public static int SumPartNumber(List<Line> lines)
		{
			return lines.Sum(x => x.CurrentValues);
		}

		public static long SumGearRatios(List<Line> lines)
		{
			return lines.Sum(x => x.GearRatio);
		}
	}
}
