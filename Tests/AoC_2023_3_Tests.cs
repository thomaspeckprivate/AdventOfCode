using AoC_2023_3;

namespace Tests
{
	public class AoC_2023_3_Tests
	{
		[Fact]
		public void Helper_Sums_Engine_Schematics()
		{
			string[] schema = new string[]{
				"467..114..",
				"...*......",
				"..35..633.",
				"......#...",
				"617*......",
				".....+.58.",
				"..592.....",
				"......755.",
				"...$.*....",
				".664.598.."
			};
			var list = new List<int>();
			var testVal = 0;
			foreach (var line in schema)
			{
				testVal += Helper.SumPartNumber(list, line);
			}

			Assert.Equal(4361, testVal);
		}
	}
}