using AoC_2023_2.Data;

String line;
try
{
	//Pass the file path and file name to the StreamReader constructor
	StreamReader sr = new StreamReader("config.txt");

	var bag = new Bag(sr.ToString());

	//Console.Write(fullValue);
}
catch (Exception e)
{
	Console.WriteLine("Exception: " + e.Message);
}
finally
{
	Console.WriteLine("Executing finally block.");
}