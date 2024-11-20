using AoC_2023_3;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;

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
			var list = new List<Line>();
			var testVal = 0;
			Line? previousLine = null;
			foreach (var line in schema)
			{
				var newLine = new Line(previousLine, line);
				previousLine = newLine;
				list.Add(newLine);
			}
			testVal = Helper.SumPartNumber(list);

			Assert.Equal(4361, testVal);
		}

		[Fact]
		public void Helper_Sums_Gear_Ratios()
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
				".664.598..",
			};
			var list = new List<Line>();
			var testVal = 0L;
			Line? previousLine = null;
			foreach (var line in schema)
			{
				var newLine = new Line(previousLine, line);
				previousLine = newLine;
				list.Add(newLine);
			}
			testVal = Helper.SumGearRatios(list);

			Assert.Equal(467835, testVal);
		}
	}
}