using Spiders.Exceptions;
using static Spiders.SpiderHuntingGame;

namespace Spiders.Cells;
internal class DownUpCell : IMapCell
{
    public DownUpCell(int x, int y)
        => Position = new Position(x, y);

    public char Symbol => '|';

    public Position Position { get; }

    public Position Move(Movement movement)
        => movement switch {
            Movement.Up => new(Position.X, Position.Y - 1),
            Movement.Down => new(Position.X, Position.Y + 1),
            Movement.Left => throw new InvalidMovementException(),
            Movement.Right => throw new InvalidMovementException(),
            _ => throw new InvalidMovementException(),
        };
}
