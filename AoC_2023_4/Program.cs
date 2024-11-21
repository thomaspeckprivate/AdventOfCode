using AoC_2023_4;

String line = string.Empty;
try
{
	//Pass the file path and file name to the StreamReader constructor
	StreamReader sr = new StreamReader("config.txt");

	line = sr.ReadLine() ?? string.Empty;
	long amount = 0;
	int ticketAmount = 0;
	var allLines = new List<Line>();
	var activeLines = new List<Line>();
	while (!string.IsNullOrEmpty(line))
	{
		//Read the next line
		var lineObject = new Line(line);
		allLines.Add(lineObject);
		amount += lineObject.amount;

		ticketAmount += Helper.AddWinningNumbers(activeLines, lineObject);

		line = sr.ReadLine() ?? string.Empty;
	}
	Console.WriteLine("Amount: " + amount);
	Console.WriteLine("Ticket Amount: " + ticketAmount);
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