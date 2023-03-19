using static Spiders.SpiderHuntingGame;

namespace Spiders.Cells;

internal class DownRightCell : IMapCell
{
    public DownRightCell(int x, int y)
        => Position = new Position(x, y);

    public char Symbol => '/';

    public Movement[] PosibleMovements => new Movement[] { Movement.Down, Movement.Right };

    public Position Position { get; }
}
