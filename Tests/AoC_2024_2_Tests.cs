using AoC_2024_2;

namespace Tests
{
	public class AoC_2024_2_Tests
	{
		[Fact]
		public void Reactor_GetNumSafeReports_gets_correct_number_of_reports()
		{
			var data = @"10 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9";
			var reactor = new Reactor(data);
			Assert.Equal(1, reactor.GetNumSafeReports());
		}

		[Fact]
		public void Reactor_GetNumSafeReportsWithDampener_gets_correct_number_of_reports()
		{
			var data = @"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9";
			var reactor = new Reactor(data);
			Assert.Equal(4, reactor.GetNumSafeReportsWithDampener());
		}
	}
}