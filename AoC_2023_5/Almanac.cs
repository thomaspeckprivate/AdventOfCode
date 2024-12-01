namespace AoC_2023_5
{
	public class Almanac
	{
		private Map[] _maps;

		public Almanac(string[] data)
		{
			_maps = data.Select(x => new Map(x)).ToArray();
		}

		public long[] GetFinalMappedValues(long[] values)
		{
			var returnVal = new long[values.Length];
			for (int i = 0; i < values.Length; i++)
			{
				long destinationValue = values[i];
				foreach (var map in _maps)
				{
					destinationValue = map.GetMappedValue(destinationValue);
				}
				returnVal[i] = destinationValue;
			}
			return returnVal;
		}

		public List<Range> GetFinalMappedRanges(List<Range> initialSeeds)
		{
			var returnVal = new List<Range>();
			foreach (var map in _maps)
			{
				returnVal.Clear();
				for (int i = 0; i < initialSeeds.Count; i++)
				{
					returnVal.AddRange(map.GetMappedRange(initialSeeds[i]));
				}
				initialSeeds = new List<Range>(returnVal);
			}
			return returnVal;
		}
	}
}
