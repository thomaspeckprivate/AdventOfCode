namespace AoC_2024_6
{
	public class Guard
	{
		public int X { get; private set; }
		public int Y { get; private set; }
		public Direction Direction { get; private set; }
		public bool InMappedArea { get { return X <= _maxX && Y <= _maxY && X >= 0 && Y >= 0; } }

		private int _maxX { get; }
		private int _maxY { get; }
		private int _initialX { get; }
		private int _initialY { get; }
		private Direction _initialDirection { get; }

		public Guard(int x, int y, Direction direction, int maxX, int maxY)
		{
			X = x;
			Y = y;
			Direction = direction;
			_initialX = x;
			_initialY = y;
			_initialDirection = direction;

			_maxX = maxX;
			_maxY = maxY;
		}

		public void ResetGuard()
		{
			X = _initialX;
			Y = _initialY;
			Direction = _initialDirection;
		}

		public Position GetNextPosition()
		{
			var x = X;
			var y = Y;
			switch (Direction)
			{
				case Direction.Left:
					x -= 1;
					break;
				case Direction.Right:
					x += 1;
					break;
				case Direction.Up:
					y -= 1;
					break;
				case Direction.Down:
					y += 1;
					break;
			}
			return new Position(x, y, Direction);
		}

		public void Move(Position position)
		{
			X = position.x;
			Y = position.y;
		}

		public void SetNextDirection()
		{
			switch (Direction)
			{
				case Direction.Left:
					Direction = Direction.Up;
					return;
			}
			Direction = Direction + 1;
		}

		public static Direction GetGuardDirection(char guardCharacter)
		{
			switch(guardCharacter)
			{
				case 'V':
					return Direction.Down;
				case '<':
					return Direction.Left;
				case '^':
					return Direction.Up;
				case '>':
					return Direction.Right;
			}
			throw new Exception("Guard direction not found");
		}
	}

	public enum Direction
	{
		Up,
		Right,
		Down,
		Left
	}
	public sealed record Position(int x, int y, Direction direction);
	public sealed record AbsolutePosition(int x, int y);
}
