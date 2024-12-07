using AoC_2024_6;

String line;
try
{
	//Pass the file path and file name to the StreamReader constructor
	var list = new Map(new StreamReader("config.txt").ReadToEnd());

	Console.WriteLine(list.GetNumberOfValidObjectPositions());
}
catch (Exception e)
{
	Console.WriteLine("Exception: " + e.Message);
}
finally
{
	Console.WriteLine("Executing finally block.");
}