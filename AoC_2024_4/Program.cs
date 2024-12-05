using AoC_2024_4;

String line;
try
{
	//Pass the file path and file name to the StreamReader constructor
	var list = new WordSearch(new StreamReader("config.txt").ReadToEnd());

	Console.WriteLine(list.CountXmasAmount());
}
catch (Exception e)
{
	Console.WriteLine("Exception: " + e.Message);
}
finally
{
	Console.WriteLine("Executing finally block.");
}