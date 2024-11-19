using System.Text.RegularExpressions;

namespace AoC_2023_2.Data
{
	public class Game
	{
		public int Id { get; init; }

		public IEnumerable<Round> Rounds { get; init; }

		public Game(string data)
		{
			var splitData = data.Split(':');

			Id = int.Parse(Regex.Match(splitData.FirstOrDefault() ?? "-1", @"\d+").Value);
			Rounds = splitData[splitData.Length - 1].Split(';').Select(x => new Round(x));
		}
	}
}
