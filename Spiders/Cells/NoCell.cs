using Spiders.Exceptions;
using static Spiders.SpiderHuntingGame;

namespace Spiders.Cells;
internal class NoCell : IMapCell
{
    public NoCell(int x, int y)
        => Position = new Position(x, y);

    public char Symbol => ' ';

    public Position Position { get; }

    public Position Move(Movement movement)
        => throw new InvalidMovementException();
}
