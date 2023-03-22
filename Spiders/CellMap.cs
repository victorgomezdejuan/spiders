using Spiders.Cells;
using System.Text;

namespace Spiders;

public static class CellMap
{

    public const int MaxXPosition = 9;
    public const int MaxYPosition = 8;
    public readonly static IMapCell[] Instance =
        new IMapCell[] {
        new DownRightCell(0, 0), new LeftRightCell(1, 0), new LeftRightCell(2, 0), new AllDirectionCell(3, 0), new LeftRightCell(4, 0),
        new AllDirectionCell(5, 0), new LeftRightCell(6, 0), new AllDirectionCell(7, 0), new LeftRightCell(8, 0), new AllDirectionCell(9, 0),

        new DownRightCell(0, 1), new DownUpCell(1, 1), new DownUpCell(2, 1), new DownUpCell(3, 1), new DownUpCell(4, 1),
        new NoCell(5, 1), new NoCell(6, 1), new NoCell(7, 1), new NoCell(8, 1), new NoCell(9, 1),

        new DownUpCell(0, 2), new DownRightCell(1, 2), new LeftRightCell(2, 2), new AllDirectionCell(3, 2), new LeftRightCell(4, 2),
        new AllDirectionCell(5, 2), new LeftRightCell(6, 2), new AllDirectionCell(7, 2), new LeftRightCell(8, 2), new AllDirectionCell(9, 2),

        new DownUpCell(0, 3), new DownRightCell(1, 3), new DownUpCell(2, 3), new DownUpCell(3, 3), new DownUpCell(4, 3),
        new DownUpCell(5, 3), new NoCell(6, 3), new NoCell(7, 3), new NoCell(8, 3), new NoCell(9, 3),

        new AllDirectionCell(0, 4), new LeftRightCell(1, 4), new LeftRightCell(2, 4), new AllDirectionCell(3, 4), new LeftRightCell(4, 4),
        new AllDirectionCell(5, 4), new LeftRightCell(6, 4), new AllDirectionCell(7, 4), new LeftRightCell(8, 4), new AllDirectionCell(9, 4),

        new DownUpCell(0, 5), new UpRightCell(1, 5), new DownUpCell(2, 5), new DownUpCell(3, 5), new DownUpCell(4, 5),
        new DownUpCell(5, 5), new NoCell(6, 5), new NoCell(7, 5), new NoCell(8, 5), new NoCell(9, 5),

        new DownUpCell(0, 6), new UpRightCell(1, 6), new LeftRightCell(2, 6), new AllDirectionCell(3, 6), new LeftRightCell(4, 6),
        new AllDirectionCell(5, 6), new LeftRightCell(6, 6), new AllDirectionCell(7, 6), new LeftRightCell(8, 6), new AllDirectionCell(9, 6),

        new UpRightCell(0, 7), new DownUpCell(1, 7), new DownUpCell(2, 7), new DownUpCell(3, 7), new DownUpCell(4, 7),
        new NoCell(5, 7), new NoCell(6, 7), new NoCell(7, 7), new NoCell(8, 7), new NoCell(9, 7),

        new UpRightCell(0, 8), new LeftRightCell(1, 8), new LeftRightCell(2, 8), new AllDirectionCell(3, 8), new LeftRightCell(4, 8),
        new AllDirectionCell(5, 8), new LeftRightCell(6, 8), new AllDirectionCell(7, 8), new LeftRightCell(8, 8), new AllDirectionCell(9, 8)
    };

    public static string MapOutput()
    {
        int index = 0;
        StringBuilder output = new();
        output.AppendLine("  0 1 2 3 4 5 6 7 8 9");

        for (int i = 0; i <= MaxYPosition; i++) {
            output.Append($"{i} ");
            for (int j = 0; j <= MaxXPosition; j++) {
                output.Append($"{Instance[index].Symbol.ToString()} ");
                index++;
            }
            output.AppendLine();
        }

        return output.ToString();
    }

    public static IMapCell CellOf(Position newPosition)
        => Instance.Single(c => c.Position.Equals(newPosition));
}