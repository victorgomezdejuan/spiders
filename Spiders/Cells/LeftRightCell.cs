using static Spiders.SpiderHuntingGame;

namespace Spiders.Cells;

internal class LeftRightCell : IMapCell
{
    public LeftRightCell(int x, int y)
        => Position = new Position(x, y);

    public char Symbol => '-';

    public Movement[] PosibleMovements => new Movement[] { Movement.Left, Movement.Right };

    public Position Position { get; }
}
