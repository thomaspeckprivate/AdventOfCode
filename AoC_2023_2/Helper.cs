using AoC_2023_2.Data;

namespace AoC_2023_2
{
	public static class Helper
	{
		public static int GetNumValidGames(Bag bag)
		{
			var returnVal = 0;
			foreach (var game in bag.Games)
			{
				var failed = false;

				foreach (var round in game.Rounds)
				{
					if (round.Red > 12 || round.Green > 13 || round.Blue > 14)
					{
						failed = true;
						break;
					}
				}
				returnVal += failed ? 0 : game.Id;
			}
			return returnVal;
		}

		public static int GetBagSumPower(Bag bag)
		{
			var returnVal = 0;
			foreach (var game in bag.Games)
			{
				var minGreen = 0;
				var minBlue = 0;
				var minRed = 0;

				foreach (var round in game.Rounds)
				{
					minGreen = Math.Max(minGreen, round.Green);
					minBlue = Math.Max(minBlue, round.Blue);
					minRed = Math.Max(minRed, round.Red);
				}
				returnVal += minGreen * minBlue * minRed;
			}
			return returnVal;
		}
	}
}
