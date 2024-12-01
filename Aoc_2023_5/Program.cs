using AoC_2023_5;

String line;
try
{
	//Pass the file path and file name to the StreamReader constructor
	long[] seeds = new StreamReader("Config\\seeds.txt").ReadToEnd().Split(' ').Select(x => long.Parse(x)).ToArray();
	for(int i = 0; i < seeds.Length; i )
	{

	}

	string[] almanacData = new string[]
	{
		new StreamReader("Config\\seed-to-soil.txt").ReadToEnd(),
		new StreamReader("Config\\soil-to-fertilizer.txt").ReadToEnd(),
		new StreamReader("Config\\fertilizer-to-water.txt").ReadToEnd(),
		new StreamReader("Config\\water-to-light.txt").ReadToEnd(),
		new StreamReader("Config\\light-to-temperature.txt").ReadToEnd(),
		new StreamReader("Config\\temperature-to-humidity.txt").ReadToEnd(),
		new StreamReader("Config\\humidity-to-location.txt").ReadToEnd(),
	};

	Console.WriteLine(Helper.MapSeedsToLocation(seeds, almanacData).Min());
}
catch (Exception e)
{
	Console.WriteLine("Exception: " + e.Message);
}
finally
{
	Console.WriteLine("Executing finally block.");
}