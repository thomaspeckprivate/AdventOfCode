namespace AoC_2023_3
{
	public class Line
	{
		public bool[] HotIndexes { get; set; }

		public CharacterObject[] Objects { get; set; }

		public Line(Line? previousLine, string data)
		{
			HotIndexes = new bool[data.Length];
			var objects = new CharacterObject[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] == '.')
				{
					objects[i] = new CharacterObject(CharacterType.None, data[i]);
				}
				else if (int.TryParse(data[i].ToString(), out var digit))
				{
					objects[i] = new CharacterObject(CharacterType.Number, data[i]);
				}
				else
				{
					objects[i] = new CharacterObject(CharacterType.Symbol, data[i]);
				}
			}
		}

		public class CharacterObject
		{
			public CharacterType Type { get; set; }

			public string Data { get; set; }
			
			public bool Valid { get; set; }

			public CharacterObject(CharacterType type, char initialChar)
			{
				Type = type;
				Data = initialChar.ToString();
			}
		}
	}

	public enum CharacterType
	{
		None,
		Symbol,
		Number
	}
}
