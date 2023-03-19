using static Spiders.SpiderHuntingGame;

namespace Spiders.Cells;
internal class DownUpCell : IMapCell
{
    public DownUpCell(int x, int y)
        => Position = new Position(x, y);

    public char Symbol => '|';

    public Movement[] PosibleMovements => new Movement[] { Movement.Down, Movement.Up };

    public Position Position { get; }
}
