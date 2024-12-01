using AoC_2024_1;

String line;
try
{
	//Pass the file path and file name to the StreamReader constructor
	var list = new LeftRightList(new StreamReader("config.txt").ReadToEnd());

	Console.WriteLine(list.GetDifference());
}
catch (Exception e)
{
	Console.WriteLine("Exception: " + e.Message);
}
finally
{
	Console.WriteLine("Executing finally block.");
}