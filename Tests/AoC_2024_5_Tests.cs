using AoC_2024_5;

namespace Tests
{
	public class AoC_2024_5_Tests
	{
		[Fact]
		public void GetSumOfMiddleValidUpdates_gets_middle_value_from_valid_updates()
		{
			var orderingData = @"47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13";
			var updateData = @"75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47";
			var program = new SafetyManual(orderingData, updateData);
			Assert.Equal(143, program.GetSumOfMiddleValidUpdates());
		}
		[Fact]
		public void GetSumOfMiddleInvalidUpdates_reorders_update_gets_middle_value()
		{
			var orderingData = @"47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13";
			var updateData = @"75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47";
			var program = new SafetyManual(orderingData, updateData);
			Assert.Equal(123, program.GetSumOfMiddleInvalidUpdates());
		}
	}
}