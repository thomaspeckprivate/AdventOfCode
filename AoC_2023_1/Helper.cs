namespace AoC_2023_1
{
	public static class Helper
	{
		public static int Read(string text)
		{
			char firstVal = '0';
			char lastVal = ' ';
			int index = 0;
			for (; index < text.Length; index++)
			{
				if (Char.IsNumber(text[index]))
				{
					firstVal = text[index];
					break;
				}
			}

			for (int i = text.Length - 1; i >= index; i--)
			{
				if (Char.IsNumber(text[i]))
				{
					lastVal = text[i];
					break;
				}
			}

			return int.Parse(new char[]{ firstVal, lastVal } );
		}
	}
}
