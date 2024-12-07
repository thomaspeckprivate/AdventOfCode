using AoC_2024_7;

try
{
	//Pass the file path and file name to the StreamReader constructor
	var list = new RopeBridge(new StreamReader("config.txt").ReadToEnd());

	Console.WriteLine(list.GetTotalCalibrationResult());
}
catch (Exception e)
{
	Console.WriteLine("Exception: " + e.Message);
}
finally
{
	Console.WriteLine("Executing finally block.");
}