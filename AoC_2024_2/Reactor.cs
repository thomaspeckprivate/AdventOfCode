using static AoC_2024_2.Reactor;

namespace AoC_2024_2
{
	public class Reactor
	{
		public List<Report> Reports;

		public Reactor(string data)
		{
			Reports = data.Split(Environment.NewLine).Select(x => new Report(x)).ToList();
		}

		public long GetNumSafeReports()
		{
			return Reports.Count(x => x.IsValid());
		}

		public long GetNumSafeReportsWithDampener()
		{
			return Reports.Count(x => x.IsAnyLevelValid());
		}

		public class Report
		{
			public List<long> Levels;
			public List<List<long>> AllPossibleLevels;

			public Report(string data)
			{
				Levels = data.Split(" ").Select(x => long.Parse(x)).ToList();
				AllPossibleLevels = new List<List<long>>() { Levels };
				for (int i = 0; i < Levels.Count; i++)
				{
					var newLevel = new List<long>(Levels);
					newLevel.RemoveAt(i);

					AllPossibleLevels.Add(newLevel);
				}
			}

			public bool IsAnyLevelValid()
			{
				foreach (var level in AllPossibleLevels)
				{
					if (IsValid(level)) return true;
				}
				return false;
			}

			public bool IsValid(List<long> levels = null)
			{
				levels = levels ?? Levels;
				bool? isIncreasing = null;
				long? prevLevel = null;

				foreach (var level in levels)
				{

					if (prevLevel != null)
					{
						var diff = level - prevLevel;

						if (diff == 0)
						{
							return false;
						}

						if (isIncreasing == null)
						{
							isIncreasing = diff > 0;
						}

						switch (isIncreasing)
						{
							case true:
								if (diff < 1 || diff > 3)
								{
									return false;
								}
								break;
							case false:
								if (diff < -3 || diff > -1)
								{
									return false;
								}
								break;
						}
					}

					prevLevel = level;
				}
				return true;
			}
		}
	}
}
