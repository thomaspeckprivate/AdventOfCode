namespace AoC_2024_5
{
	public class SafetyManual
	{
		// Check if will break ordering
		IReadOnlyDictionary<long, List<long>> WillBreakOrdering { get; }
		IReadOnlyList<long[]> Updates { get; }

		public SafetyManual(string orderingData, string updateData)
		{
			var orderingSplit = orderingData.Split(Environment.NewLine);
			var updateSplit = updateData.Split(Environment.NewLine);

			var dict = new Dictionary<long, List<long>>();
			foreach (var split in orderingSplit)
			{
				var order = split.Split('|').Select(x => long.Parse(x));
				if (dict.TryGetValue(order.Last(), out var theList))
				{
					theList.Add(order.First());
				}
				else
				{
					dict.Add(order.Last(), new List<long>() { order.First() });
				}
			}

			var updates = new List<long[]>();
			foreach (var update in updateSplit)
			{
				updates.Add(update.Split(',').Select(x => long.Parse(x)).ToArray());
			}

			WillBreakOrdering = dict;
			Updates = updates;
		}

		public long GetSumOfMiddleValidUpdates()
		{
			var amount = 0L;
			foreach (var update in Updates)
			{
				amount += IsUpdateValid(update) ? update[update.Count() / 2] : 0;
			}

			return amount;
		}

		public long GetSumOfMiddleInvalidUpdates()
		{
			var amount = 0L;
			foreach (var update in Updates)
			{
				amount += ReorderUpdate(update);
			}

			return amount;
		}

		private bool IsUpdateValid(IEnumerable<long> update)
		{
			var invalidNumbers = new List<long>();
			foreach (var number in update)
			{
				if (invalidNumbers.Contains(number))
				{
					return false;
				}

				if (WillBreakOrdering.TryGetValue(number, out var newInvalidNumbers))
				{
					invalidNumbers.AddRange(newInvalidNumbers);
				}
			}
			return true;
		}

		private long ReorderUpdate(long[] update)
		{
			long[] updateList = new long[update.Length];
			Array.Copy(update, updateList, updateList.Length);

			if (IsUpdateValid(updateList))
			{
				return 0;
			}

			do
			{
				// ew ew ew ew ew
				var invalidNumbers = new List<long>();
				for (int i = 0; i < updateList.Length; i++)
				{
					if (invalidNumbers.Contains(updateList[i]))
					{
						var switchedNumber = updateList[i];
						updateList[i] = updateList[i - 1];
						updateList[i - 1] = switchedNumber;
					}

					if (WillBreakOrdering.TryGetValue(updateList[i], out var newInvalidNumbers))
					{
						invalidNumbers.AddRange(newInvalidNumbers);
					}
				}
			}
			while (!IsUpdateValid(updateList));

			return updateList[updateList.Length / 2];
		}
	}
}
