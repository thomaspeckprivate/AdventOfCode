using AoC_2024_6;

namespace Tests
{
	public class AoC_2024_6_Tests
	{
		[Fact]
		public void GetGuardVisitedPositions_returns_X_filled_positions()
		{
			var data = @"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";
			var program = new Map(data);
			Assert.Equal(41, program.GetGuardVisitedPositions(out var _));
		}

		[Fact]
		public void GetNumberOfValidObjectPositions_gets_number_of_positions_for_placed_object_to_make_loop()
		{
			var data = @"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";
			var program = new Map(data);
			Assert.Equal(6, program.GetNumberOfValidObjectPositions());
		}
	}
}