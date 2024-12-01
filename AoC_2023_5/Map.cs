namespace AoC_2023_5
{
	public class Map
	{
		private Mapping[] _mappings;

		public Map(string data)
		{
			_mappings = data.Split(Environment.NewLine).Select(x => new Mapping(x)).ToArray();
		}

		public long GetMappedValue(long value)
		{
			foreach (var mapping in _mappings)
			{
				if (mapping.TryGetMappedValue(value, out var mappingValue))
				{
					return mappingValue;
				}
			}
			return value;
		}

		public List<Range> GetMappedRange(Range range)
		{
			var destinationRanges = new List<Range>();
			var remainingRanges = new List<Range>() { range };
			foreach (var mapping in _mappings)
			{
				if (mapping.TryGetMappedRange(remainingRanges, out destinationRanges))
				{
					return destinationRanges;
				}
			}
			return destinationRanges;
		}
	}
}
