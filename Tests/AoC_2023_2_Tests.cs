using AoC_2023_2;
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

		[Fact]
		public void Helper_Gets_Valid_Games()
		{
			var bag = new Bag("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\r\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\r\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\r\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\r\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");
			var numberOfGames = Helper.GetNumValidGames(bag);
			Assert.Equal(8, numberOfGames);
		}

		[Fact]
		public void Helper_Gets_Sum_Power_From_Valid_Games()
		{
			var bag = new Bag("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\r\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\r\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\r\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\r\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");
			var numberOfGames = Helper.GetBagSumPower(bag);
			Assert.Equal(2286, numberOfGames);
		}
	}
}