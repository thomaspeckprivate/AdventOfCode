using AoC_2024_1;

namespace Tests
{
	public class AoC_2024_1_Tests
	{
		[Fact]
		public void GetDifference_gets_sorted_list_difference()
		{
			var data = @"3   4
4   3
2   5
1   3
3   9
3   3";
			var list = new LeftRightList(data);
			Assert.Equal(11, list.GetDifference());
		}
	}
}