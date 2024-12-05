using AoC_2024_3;

namespace Tests
{
	public class AoC_2024_3_Tests
	{
		[Fact]
		public void SumResults_sums_all_valid_mul_instructions()
		{
			var data = @"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
			var program = new MulInstructions(data);
			Assert.Equal(161, program.SumResults());
		}

		[Fact]
		public void SumComplexResults_sums_all_valid_mul_instructions()
		{
			var data = @"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
			var program = new MulInstructions(data);
			Assert.Equal(48, program.SumComplexResults());
		}
	}
}