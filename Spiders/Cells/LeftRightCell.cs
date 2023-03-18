using Spiders.Exceptions;
using static Spiders.SpiderHuntingGame;

namespace Spiders.Cells;

internal class LeftRightCell : IMapCell
{
    public LeftRightCell(int x, int y)
        => Position = new Position(x, y);

    public char Symbol => '-';

    public Position Position { get; }

    public Position Move(Movement movement)
        => movement switch {
            Movement.Up => throw new InvalidMovementException(),
            Movement.Down => throw new InvalidMovementException(),
            Movement.Left => new(Position.X - 1, Position.Y),
            Movement.Right => new(Position.X + 1, Position.Y),
            _ => throw new InvalidMovementException(),
        };
}
