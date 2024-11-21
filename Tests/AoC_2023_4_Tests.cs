using AoC_2023_4;

namespace Tests
{
	public class AoC_2023_4_Tests
	{
		[Fact]
		public void Line_sums_winning_numbers()
		{
			string[] schema = new string[]{
				"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
				"Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
				"Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
				"Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
				"Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
				"Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
			};
			long testVal = 0;
			foreach (var line in schema)
			{
				var newLine = new Line(line);
				testVal += newLine.amount;
			}

			Assert.Equal(13, testVal);
		}

		[Fact]
		public void Line_adds_additional_won_scratchcards()
		{
			string[] schema = new string[]{
				"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
				"Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
				"Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
				"Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
				"Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
				"Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
			};
			long testVal = 0;
			var activeLines = new List<Line>();
			foreach (var line in schema)
			{
				var lienObject = new Line(line);
				testVal += Helper.AddWinningNumbers(activeLines, lienObject);
			}

			Assert.Equal(30, testVal);
		}
	}
}