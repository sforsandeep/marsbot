namespace Marsbot;
// Direction enum with rotation logic
public enum Direction
{
    North = 0,
    East = 1,
    South = 2,
    West = 3
}

public static class DirectionExtensions
{
    public static Direction TurnLeft(this Direction direction)
    {
        return (Direction)(((int)direction + 3) % 4);
    }

    public static Direction TurnRight(this Direction direction)
    {
        return (Direction)(((int)direction + 1) % 4);
    }

    public static Position GetForwardPosition(this Direction direction, Position current)
    {
        return direction switch
        {
            Direction.North => new Position(current.X, current.Y + 1),
            Direction.East => new Position(current.X + 1, current.Y),
            Direction.South => new Position(current.X, current.Y - 1),
            Direction.West => new Position(current.X - 1, current.Y),
            _ => throw new ArgumentException($"Invalid direction: {direction}")
        };
    }

    public static char ToChar(this Direction direction)
    {
        return direction switch
        {
            Direction.North => 'N',
            Direction.East => 'E',
            Direction.South => 'S',
            Direction.West => 'W',
            _ => throw new ArgumentException($"Invalid direction: {direction}")
        };
    }

    public static Direction FromChar(char c)
    {
        return c switch
        {
            'N' => Direction.North,
            'E' => Direction.East,
            'S' => Direction.South,
            'W' => Direction.West,
            _ => throw new ArgumentException($"Invalid direction character: {c}")
        };
    }
}

