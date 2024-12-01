namespace AoC_2023_5
{
	public static class Helper
	{
		public static long[] MapSeedsToLocation(long[] seeds, string[] almanacData)
		{
			return new Almanac(almanacData).GetFinalMappedValues(seeds);
		}

		public static List<Range> MapSeedRangesToLocation(List<Range> seeds, string[] almanacData)
		{
			return new Almanac(almanacData).GetFinalMappedRanges(seeds);
		}
	}
}
