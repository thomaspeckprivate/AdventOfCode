using AoC_2024_4;

namespace Tests
{
	public class AoC_2024_4_Tests
	{
		[Fact]
		public void CountXmasAmount_counts_all_xmas_strings()
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
		[Fact]
		public void CountMaxPositions_finds_all_x_mas_strings()
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
			Assert.Equal(9, program.CountMasPositions());
		}
	}
}