namespace AoC_2024_3
{
	public class MulInstructions
	{
		List<long?> Multiplications = new List<long?>();

		public MulInstructions(string data)
		{
			var mulData = data.Split("mul(");
			foreach (var mul in mulData)
			{
				if (TryGetValidInput(mul, out var multiplicationValue))
				{
					Multiplications.Add(multiplicationValue);
				}
			}
		}

		public long SumResults()
		{
			return Multiplications.Sum(x => x ?? 0);
		}

		private bool TryGetValidInput(string currentSequence, out long? multiplicationValue)
		{
			var updatedSequence = string.Empty;
			multiplicationValue = null;
			bool hasCommaBeenHit = false;
			foreach (var character in currentSequence)
			{
				if (IsCharValid(character, updatedSequence, hasCommaBeenHit, out updatedSequence, out var number))
				{
					if (number != null)
					{
						if (multiplicationValue == null)
						{
							hasCommaBeenHit = true;
							multiplicationValue = number;
							updatedSequence = string.Empty;
						}
						else
						{
							multiplicationValue = multiplicationValue * number;
							return true;
						}
					}
				}
				else
				{
					return false;
				}
			}
			return false;
		}

		private bool IsCharValid(char character, string currentSequence, bool hasEncounteredComma, out string updatedSequence, out long? number)
		{
			updatedSequence = currentSequence;
			number = null;
			if (long.TryParse(character.ToString(), out var _))
			{
				updatedSequence += character;
				return true;
			}

			switch (character)
			{
				case ',':
					if (hasEncounteredComma)
					{
						return false;
					}
					number = long.Parse(updatedSequence);
					return true;
				case ')':
					if (!hasEncounteredComma)
					{
						return false;
					}
					number = long.Parse(updatedSequence);
					return true;
			}

			return false;
		}
	}
}
