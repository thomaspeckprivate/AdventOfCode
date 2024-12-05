using AoC_2024_4;

namespace Tests
{
	public class AoC_2024_4_Tests
	{
		[Fact]
		public void SumResults_sums_all_valid_mul_instructions()
		{
			var data = @"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX";
			var program = new WordSearch(data);
			Assert.Equal(18, program.CountXmasAmount());
		}
	}
}