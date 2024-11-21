using System.Runtime.CompilerServices;

namespace AoC_2023_4
{
	public static class Helper
	{
		public static int AddWinningNumbers(List<Line> activeLines, Line newLine)
		{
			var toRemove = new List<Func<bool>>();
			foreach (var activeLine in activeLines)
			{
				if (activeLine.winningNumberAmount > 0)
				{
					newLine.existingTickets += activeLine.existingTickets;
					activeLine.winningNumberAmount--;
				}
				else
				{
					toRemove.Add(() => activeLines.Remove(activeLine));
				}
			}

			foreach (var todo in toRemove)
			{
				todo.Invoke();
			}

			if (newLine.winningNumberAmount > 0)
			{
				activeLines.Add(newLine);
			}

			return newLine.existingTickets;
		}
	}
}
