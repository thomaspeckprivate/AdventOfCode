using AoC_2024_2;

String line;
try
{
	//Pass the file path and file name to the StreamReader constructor
	var list = new Reactor(new StreamReader("config.txt").ReadToEnd());

	Console.WriteLine(list.GetNumSafeReportsWithDampener());
}
catch (Exception e)
{
	Console.WriteLine("Exception: " + e.Message);
}
finally
{
	Console.WriteLine("Executing finally block.");
}