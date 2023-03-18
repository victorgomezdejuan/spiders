using Spiders.Exceptions;
using static Spiders.SpiderHuntingGame;

namespace Spiders.Cells;

internal class UpRightCell : IMapCell
{
    public UpRightCell(int x, int y)
        => Position = new Position(x, y);

    public char Symbol => '\\';

    public Position Position { get; }

    public Position Move(Movement movement)
        => movement switch {
            Movement.Up => new(Position.X, Position.Y - 1),
            Movement.Down => throw new InvalidMovementException(),
            Movement.Left => throw new InvalidMovementException(),
            Movement.Right => new(Position.X + 1, Position.Y),
            _ => throw new InvalidMovementException(),
        };
}
