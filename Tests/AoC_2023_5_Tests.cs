using AoC_2023_5;

namespace Tests
{
	public class AoC_2023_5_Tests
	{
		[Fact]
		public void Map_seeds_to_destination()
		{
			long[] seeds = new long[]{ 79, 14, 55, 13 };
			string[] schema = new string[]{
				"50 98 2\r\n52 50 48",
				"0 15 37\r\n37 52 2\r\n39 0 15",
				"49 53 8\r\n0 11 42\r\n42 0 7\r\n57 7 4",
				"88 18 7\r\n18 25 70",
				"45 77 23\r\n81 45 19\r\n68 64 13",
				"0 69 1\r\n1 0 69",
				"60 56 37\r\n56 93 4"
			};
			long[] testVals = Helper.MapSeedsToLocation(seeds, schema);
			long[] expectedVals = new long[] { 82, 43, 86, 35 };
			for (int i = 0; i < expectedVals.Length; i++)
			{
				Assert.Equal(expectedVals[i], testVals[i]);
			}
		}
	}
}