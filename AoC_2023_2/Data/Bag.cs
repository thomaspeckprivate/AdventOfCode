namespace AoC_2023_2.Data
{
	public class Bag
	{
		public IEnumerable<Game> Games { get; init; }

		public Bag(string data)
		{
			var gamesData = data.Split(Environment.NewLine);
			Games = gamesData.Select(x => new Game(x));
		}
	}
}
