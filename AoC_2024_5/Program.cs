using AoC_2024_5;

String line;
try
{
	//Pass the file path and file name to the StreamReader constructor
	var list = new SafetyManual(new StreamReader("pageOrdering.txt").ReadToEnd(), new StreamReader("pageUpdate.txt").ReadToEnd());

	Console.WriteLine(list.GetSumOfMiddleInvalidUpdates());
}
catch (Exception e)
{
	Console.WriteLine("Exception: " + e.Message);
}
finally
{
	Console.WriteLine("Executing finally block.");
}