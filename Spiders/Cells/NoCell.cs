using static Spiders.SpiderHuntingGame;

namespace Spiders.Cells;

public class NoCell : IMapCell
{
    public NoCell(int x, int y)
        => Position = new Position(x, y);

    public char Symbol => ' ';

    public Movement[] PosibleMovements => Array.Empty<Movement>();

    public Position Position { get; }
}
