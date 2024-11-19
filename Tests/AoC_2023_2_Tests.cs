using AoC_2023_2.Data;

namespace Tests
{
	public class AoC_2023_2_Tests
	{
		[Fact]
		public void Bag_Creates_One_Game_One_Round()
		{
			var game = "Game 1: 1 green";
			var bag = new Bag(game);
			Assert.Single(bag.Games);
			Assert.Equal(1, bag.Games.First().Id);
			Assert.Single(bag.Games.First().Rounds);
			Assert.Equal(1, bag.Games.First().Rounds.First().Green);
		}

		[Fact]
		public void Bag_Saves_Green_Amount()
		{
			var game = "Game 1: 1 green";
			var bag = new Bag(game);
			Assert.Equal(1, bag.Games.First().Rounds.First().Green);
		}

		[Fact]
		public void Bag_Saves_Red_Amount()
		{
			var game = "Game 1: 1 red";
			var bag = new Bag(game);
			Assert.Equal(1, bag.Games.First().Rounds.First().Red);
		}

		[Fact]
		public void Bag_Saves_Blue_Amount()
		{
			var game = "Game 1: 1 blue";
			var bag = new Bag(game);
			Assert.Equal(1, bag.Games.First().Rounds.First().Blue);
		}

		[Fact]
		public void Bag_Saves_Multiple_Stones()
		{
			var game = "Game 1: 1 blue, 2 green, 3 red";
			var bag = new Bag(game);
			Assert.Equal(1, bag.Games.First().Rounds.First().Blue);
			Assert.Equal(2, bag.Games.First().Rounds.First().Green);
			Assert.Equal(3, bag.Games.First().Rounds.First().Red);
		}

		[Fact]
		public void Bag_Saves_Multiple_Rounds()
		{
			var game = "Game 1: 1 blue, 2 green, 3 red ; 4 blue";
			var bag = new Bag(game);
			Assert.Equal(1, bag.Games.First().Rounds.First().Blue);
			Assert.Equal(2, bag.Games.First().Rounds.First().Green);
			Assert.Equal(3, bag.Games.First().Rounds.First().Red);
			Assert.Equal(4, bag.Games.First().Rounds.Last().Blue);
		}

		[Fact]
		public void Bag_Saves_Multiple_Games()
		{
			var game = "Game 1: 1 green\r\nGame 2: 9 blue";
			var bag = new Bag(game);
			Assert.Equal(1, bag.Games.First().Rounds.First().Green);
			Assert.Equal(9, bag.Games.Last().Rounds.First().Blue);
		}
	}
}