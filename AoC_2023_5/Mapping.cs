namespace AoC_2023_5
{
	public class Mapping
	{
		public long Destination { get; }
		public long SourceStart { get; }
		public long SourceEnd { get; }

		public Mapping(string data)
		{
			var mappings = data.Split(" ");
			Destination = long.Parse(mappings[0]);
			SourceStart = long.Parse(mappings[1]);
			SourceEnd = SourceStart + long.Parse(mappings[2]) - 1;
		}

		public bool TryGetMappedValue(long value, out long destination)
		{
			destination = Destination + (value - SourceStart);
			return value >= SourceStart && value <= SourceEnd;
		}

		public bool TryGetMappedRange(List<Range> rangesToMap, out List<Range> destinationRanges)
		{
			destinationRanges = new List<Range>();
			// Need to determine if range matches
			foreach(var range in rangesToMap)
			{
				var startLower = SourceEnd >= range.Start;
				var startHigher = SourceStart <= range.Start;
				var endLower = SourceEnd >= range.End;
				var endHigher = SourceStart <= range.End;

				var startWithin = startHigher && startLower;
				var endWithin = endLower && endHigher;

				if (startWithin && endWithin)
				{
					destinationRanges = rangesToMap;
					return true;
				}

				if (startWithin)
				{

				}


			}
			//destination = Destination + (value - SourceStart);
			//return value >= SourceStart && value <= SourceEnd;
			return false;
		}
	}
}
