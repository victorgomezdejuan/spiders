using static Spiders.SpiderHuntingGame;

namespace Spiders.Cells;
internal class AllDirectionCell : IMapCell
{
    public AllDirectionCell(int x, int y)
        => Position = new Position(x, y);

    public char Symbol => 'O';

    public Movement[] PosibleMovements => new Movement[] { Movement.Left, Movement.Right, Movement.Down, Movement.Up };

    public Position Position { get; }
}
