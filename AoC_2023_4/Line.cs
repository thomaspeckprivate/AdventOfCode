namespace AoC_2023_4
{
	public class Line
	{
		public long amount = 0;
		public List<string> winningNumbers = new List<string>();
		public int winningNumberAmount = 0;
		public int existingTickets = 1;

		public Line(string data)
		{
			var actualData = data.Split(':').Last();
			var numericalData = actualData.Split("|");
			winningNumbers = numericalData.First().Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToList();
			var yourNumbers = numericalData.Last().Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToList();
			var found = false;
			foreach (var yourNumber in yourNumbers)
			{
				if (winningNumbers.Contains(yourNumber))
				{
					winningNumberAmount++;
					amount = found ? amount * 2 : 1;
					found = true;
				}
			}
		}
	}
}
