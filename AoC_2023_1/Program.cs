// See https://aka.ms/new-console-template for more information
using AoC_2023_1;

const int threadcount = 10;

for (int i = 0; i < threadcount; i++)
{

}

String line;
try
{
	//Pass the file path and file name to the StreamReader constructor
	StreamReader sr = new StreamReader("Config\\config.txt");

	//Continue to read until you reach end of file
	var fullValue = 0;
	line = sr.ReadLine();
	while (line != null)
	{
		//Read the next line
		fullValue += Helper.Read(line);
		line = sr.ReadLine();
	}
	//close the file
	sr.Close();
	Console.Write(fullValue);
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