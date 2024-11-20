using AoC_2023_3;

String line = string.Empty;
try
{
	//Pass the file path and file name to the StreamReader constructor
	StreamReader sr = new StreamReader("config.txt");

	line = sr.ReadLine() ?? string.Empty;
	var lines = new List<Line>();
	Line lineObject = null;
	while (!string.IsNullOrEmpty(line))
	{
		//Read the next line
		var newLine = new Line(lineObject, line);
		lines.Add(newLine);
		lineObject = newLine;
		line = sr.ReadLine() ?? string.Empty;
	}
	Console.WriteLine(Helper.SumGearRatios(lines));
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