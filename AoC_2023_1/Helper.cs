namespace AoC_2023_1
{
	public static class Helper
	{

		public static int Read(string text)
		{
			char firstVal = '0';
			char lastVal = ' ';
			int index = 0;
			string digitSequence = string.Empty;
			for (; index < text.Length; index++)
			{
				if (Char.IsNumber(text[index]))
				{
					digitSequence = string.Empty;
					firstVal = text[index];
					break;
				}
				else
				{
					var num = GetValidNumber(text[index], digitSequence, true, out digitSequence);
					if (num >= 0)
					{
						firstVal = char.Parse(num.ToString());
						index = index - digitSequence.Length;
						break;
					}
				}
			}

			digitSequence = string.Empty;
			for (int i = text.Length - 1; i >= index; i--)
			{
				if (Char.IsNumber(text[i]))
				{
					digitSequence = string.Empty;
					lastVal = text[i];
					break;
				}
				else
				{
					var num = GetValidNumber(text[i], digitSequence, false, out digitSequence);
					if (num >= 0)
					{
						lastVal = char.Parse(num.ToString());
						break;
					}
				}
			}

			return int.Parse(new char[]{ firstVal, lastVal } );
		}

		// May need to be expanded upon in other cases - luckily digit strings are non repeating chars but if digits existed of string 'abcd', and another of string 'bca' - there would be an error if string 'abca' was shown.
		// As we would iterate over initial 'abc' then fail, we would need to fall back on 'bc' and retry to get the correct result. This cannot occur with digit strings though so thats cool.
		// We almost have an issue with initial chars being taken:
		// e.g.'one' & 'six' -> 'sone' -> needs to retry GetValidNumber with updatedSequence being empty.
		// But there is no number which relies on a substring of length >1 in any other number.

		// You idiot there 'seven' & 'five' -> 'fiven' will fail backwards
		private static int GetValidNumber(char nextChar, string currentSequence, bool isForwards, out string updatedSequence)
		{
			if (isForwards)
			{
				updatedSequence = currentSequence + nextChar;
				switch (nextChar)
				{
					case 'e':
						switch (currentSequence)
						{
							case "on":
								return 1;
							case "thr":
								break;
							case "thre":
								return 3;
							case "fiv":
								return 5;
							case "s":
								break;
							case "sev":
								break;
							case "":
								break;
							case "nin":
								return 9;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
						break;
					case 'f':
						switch (currentSequence)
						{
							case "":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
						break;
					case 'g':
						switch (currentSequence)
						{
							case "ei":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
						break;
					case 'h':
						switch (currentSequence)
						{
							case "t":
								break;
							case "eig":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
						break;
					case 'i':
						switch (currentSequence)
						{
							case "f":
								break;
							case "s":
								break;
							case "e":
								break;
							case "n":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
						break;
					case 'n':
						switch (currentSequence)
						{
							case "o":
								break;
							case "seve":
								return 7;
							case "":
								break;
							case "ni":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
						break;
					case 'o':
						switch (currentSequence)
						{
							case "":
								break;
							case "tw":
								return 2;
							case "f":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
						break;
					case 'r':
						switch (currentSequence)
						{
							case "th":
								break;
							case "fou":
								return 4;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
						break;
					case 's':
						switch (currentSequence)
						{
							case "":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
						break;
					case 't':
						switch (currentSequence)
						{
							case "":
								break;
							case "eigh":
								return 8;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
						break;
					case 'u':
						switch (currentSequence)
						{
							case "fo":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
						break;
					case 'v':
						switch (currentSequence)
						{
							case "fi":
								break;
							case "se":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
						break;
					case 'w':
						switch (currentSequence)
						{
							case "t":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
						break;
					case 'x':
						switch (currentSequence)
						{
							case "si":
								return 6;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence[1..], isForwards, out updatedSequence);
						}
				}
			}
			else
			{
				updatedSequence = nextChar + currentSequence;
				switch (nextChar)
				{
					case 'e':
						switch (currentSequence)
						{
							case "":
								break;
							case "e":
								break;
							case "n":
								break;
							case "ven":
								break;
							case "ight":
								return 8;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
						break;
					case 'f':
						switch (currentSequence)
						{
							case "our":
								return 4;
							case "ive":
								return 5;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
					case 'g':
						switch (currentSequence)
						{
							case "ht":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
						break;
					case 'h':
						switch (currentSequence)
						{
							case "ree":
								break;
							case "t":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
						break;
					case 'i':
						switch (currentSequence)
						{
							case "ve":
								break;
							case "x":
								break;
							case "ght":
								break;
							case "ne":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
						break;
					case 'n':
						switch (currentSequence)
						{
							case "e":
								break;
							case "":
								break;
							case "ine":
								return 9;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
						break;
					case 'o':
						switch (currentSequence)
						{
							case "ne":
								return 1;
							case "":
								break;
							case "ur":
								break;
							case "x":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
						break;
					case 'r':
						switch (currentSequence)
						{
							case "ee":
								break;
							case "":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
						break;
					case 's':
						switch (currentSequence)
						{
							case "ix":
								return 6;
							case "even":
								return 7;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
						break;
					case 't':
						switch (currentSequence)
						{
							case "wo":
								return 2;
							case "hree":
								return 3;
							case "":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
						break;
					case 'u':
						switch (currentSequence)
						{
							case "r":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
						break;
					case 'v':
						switch (currentSequence)
						{
							case "e":
								break;
							case "en":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
						break;
					case 'w':
						switch (currentSequence)
						{
							case "o":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
						break;
					case 'x':
						switch (currentSequence)
						{
							case "":
								break;
							default:
								return string.IsNullOrEmpty(currentSequence) ? -1 : GetValidNumber(nextChar, currentSequence.Remove(currentSequence.Length - 1), isForwards, out updatedSequence);
						}
						break;
				}
			}
			return -1;
		}
	}
}
