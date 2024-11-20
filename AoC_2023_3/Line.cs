namespace AoC_2023_3
{
	public class Line
	{
		public List<int> SymbolIndexes { get; set; }

		public Dictionary<CharacterObject, List<int>> GearIndexes { get; set; }

		public CharacterObject[] Objects { get; set; }

		public int CurrentValues { get; set; }

		public long GearRatio { get { return GearIndexes.Keys.Sum(x => x.PartNumbers.Keys.Count == 2 ? x.PartNumbers.Values.Aggregate(1, (y, z) => y * z) : 0); } }

		public Line(Line? previousLine, string data)
		{
			SymbolIndexes = new List<int>();
			GearIndexes = new Dictionary<CharacterObject, List<int>>();
			Objects = new CharacterObject[data.Length];
			CharacterObject? actingObject = null;

			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] == '.')
				{
					actingObject = actingObject != null && actingObject.Type == CharacterType.None ? actingObject : new CharacterObject(CharacterType.None);
					Objects[i] = actingObject;
				}
				else if (int.TryParse(data[i].ToString(), out var _))
				{
					actingObject = actingObject != null && actingObject.Type == CharacterType.Number ? actingObject : new CharacterObject(CharacterType.Number);
					actingObject.Data += data[i];
					Objects[i] = actingObject;
				}
				else
				{
					actingObject = data[i] == '*' ? new CharacterObject(CharacterType.Gear): new CharacterObject(CharacterType.NonGear);
					Objects[i] = actingObject;
					var min = Math.Max(0, i - 1);
					var count = Math.Min(data.Length, min + 3) - min;
					var range = Enumerable.Range(min, count).ToList();
					SymbolIndexes.AddRange(range);
					if (data[i] == '*')
					{
						GearIndexes.Add(actingObject, range);
					}
				}
			}
			var allHotIndexes = SymbolIndexes.Concat(previousLine?.SymbolIndexes ?? new()).ToList();

			foreach (var index in allHotIndexes)
			{
				// Previous Line
				actingObject = previousLine?.Objects[index];
				if (actingObject != null && actingObject.Type == CharacterType.Number)
				{
					if (!actingObject.Valid)
					{
						actingObject.Valid = true;
						previousLine!.CurrentValues += int.Parse(actingObject.Data);
					}
				}

				// Current Line
				actingObject = Objects[index];
				if (actingObject != null && actingObject.Type == CharacterType.Number)
				{
					if (!actingObject.Valid)
					{
						actingObject.Valid = true;
						CurrentValues += int.Parse(actingObject.Data);
					}
				}
			}

			var allGearIndexes = GearIndexes.Concat(previousLine?.GearIndexes ?? new()).ToDictionary(x => x.Key, y => y.Value);
			foreach (var dataObject in allGearIndexes)
			{
				foreach (var index in dataObject.Value)
				{
					// Previous Line
					actingObject = previousLine?.Objects[index];
					if (actingObject != null && actingObject.Type == CharacterType.Number)
					{
						dataObject.Key.PartNumbers.TryAdd(actingObject.Id, int.Parse(actingObject.Data));
					}

					// Current Line
					actingObject = Objects[index];
					if (actingObject != null && actingObject.Type == CharacterType.Number)
					{
						dataObject.Key.PartNumbers.TryAdd(actingObject.Id, int.Parse(actingObject.Data));
					}
				}
			}
		}

		public class CharacterObject
		{
			public Guid Id { get; }

			public CharacterType Type { get; set; }

			public string Data { get; set; } = string.Empty;
			
			public bool Valid { get; set; }

			public Dictionary<Guid, int> PartNumbers = new Dictionary<Guid, int>();


			public CharacterObject(CharacterType type)
			{
				Id = Guid.NewGuid();
				Type = type;
			}
		}
	}

	[Flags]
	public enum CharacterType
	{
		None,
		Gear,
		NonGear,
		Symbol = Gear | NonGear,
		Number
	}
}
