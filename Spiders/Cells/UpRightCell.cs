using static Spiders.SpiderHuntingGame;

namespace Spiders.Cells;

internal class UpRightCell : IMapCell
{
    public UpRightCell(int x, int y)
        => Position = new Position(x, y);

    public char Symbol => '\\';

    public Movement[] PosibleMovements => new Movement[] { Movement.Up, Movement.Right };

    public Position Position { get; }
}