namespace AoC_2023_5
{
	public class Range
	{
		public long Start { get; }

		public long End { get; }

		public Range(long start, long count)
		{
			Start = start;
			End = start + (count - 1);
		}
	}
}
