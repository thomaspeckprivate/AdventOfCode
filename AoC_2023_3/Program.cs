using AoC_2023_3;

String line = string.Empty;
try
{
	//Pass the file path and file name to the StreamReader constructor
	StreamReader sr = new StreamReader("config.txt");

	line = sr.ReadLine() ?? string.Empty;
	var symbolIndexes = new List<int>();
	var sum = 0;
	while (string.IsNullOrEmpty(line))
	{
		//Read the next line
		sum += Helper.SumPartNumber(symbolIndexes, line);
		line = sr.ReadLine() ?? string.Empty;
	}
	//close the file
	sr.Close();
	Console.ReadLine();
}
catch (Exception e)
{
	Console.WriteLine("Exception: " + e.Message);
}
finally
{
	Console.WriteLine("Executing finally block.");
}