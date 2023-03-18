using static Spiders.SpiderHuntingGame;

namespace Spiders.Cells;

public interface IMapCell
{
    Position Position { get; }

    char Symbol { get; }

    Position Move(Movement movement);
}
