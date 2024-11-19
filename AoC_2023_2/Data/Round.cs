using System.Text.RegularExpressions;

namespace AoC_2023_2.Data
{
	public class Round
	{
		public int Blue { get; set; }

		public int Green { get; set; }

		public int Red { get; set; }

		public Round(string data)
		{
			var splitData = data.Split(',');
			foreach (var split in splitData)
			{
				if (split.Contains("blue"))
				{
					Blue = int.Parse(Regex.Match(split ?? "0", @"\d+").Value);
				}
				else if (split.Contains("red"))
				{
					Red = int.Parse(Regex.Match(split ?? "0", @"\d+").Value);
				}
				else if (split.Contains("green"))
				{
					Green = int.Parse(Regex.Match(split ?? "0", @"\d+").Value);
				}
			}
		}
	}
}
