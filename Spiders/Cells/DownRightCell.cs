using Spiders.Exceptions;
using static Spiders.SpiderHuntingGame;

namespace Spiders.Cells;

internal class DownRightCell : IMapCell
{
    public DownRightCell(int x, int y)
        => Position = new Position(x, y);

    public char Symbol => '/';

    public Position Position { get; }

    public Position Move(Movement movement)
        => movement switch {
            Movement.Up => throw new InvalidMovementException(),
            Movement.Down => new(Position.X, Position.Y + 1),
            Movement.Left => throw new InvalidMovementException(),
            Movement.Right => new(Position.X + 1, Position.Y),
            _ => throw new InvalidMovementException(),
        };
}
