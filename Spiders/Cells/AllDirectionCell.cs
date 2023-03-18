using Spiders.Exceptions;
using static Spiders.SpiderHuntingGame;

namespace Spiders.Cells;
internal class AllDirectionCell : IMapCell
{
    public AllDirectionCell(int x, int y)
        => Position = new Position(x, y);

    public char Symbol => 'O';

    public Position Position { get; }

    public Position Move(Movement movement)
        => movement switch {
            Movement.Up => new(Position.X, Position.Y - 1),
            Movement.Down => new(Position.X, Position.Y + 1),
            Movement.Left => new(Position.X - 1, Position.Y),
            Movement.Right => new(Position.X + 1, Position.Y),
            _ => throw new InvalidMovementException(),
        };
}
