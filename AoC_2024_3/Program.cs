using AoC_2024_3;

String line;
try
{
	//Pass the file path and file name to the StreamReader constructor
	var list = new MulInstructions(new StreamReader("config.txt").ReadToEnd());

	Console.WriteLine(list.SumComplexResults());
}
catch (Exception e)
{
	Console.WriteLine("Exception: " + e.Message);
}
finally
{
	Console.WriteLine("Executing finally block.");
}