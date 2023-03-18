using Spiders.Cells;
using Spiders.Exceptions;
using System.Text;

namespace Spiders;

public class SpiderHuntingGame
{
    public enum Movement
    {
        Up,
        Down,
        Left,
        Right
    }

    private enum Axis { X, Y }

    private const int MaxXPosition = 9;
    private const int MaxYPosition = 8;
    private const int InitialDistance = 2;
    private static readonly IMapCell[] Map = GetMap();

    public SpiderHuntingGame()
    {
        MyPosition = MyRandomPosition();
        PreyPosition = PreyRandomPosition();
        MyTurn = true;
    }

    public virtual Position MyPosition { get; protected set; }
    public virtual Position PreyPosition { get; protected set; }
    public bool MyTurn { get; private set; }
    public string Output => string.Format(
        MapOutput() + "\r\n" +
        "My position:{0}, {1}\r\n" +
        "Prey's position: {2}, {3}",
        MyPosition.X, MyPosition.Y, PreyPosition.X, PreyPosition.Y);

    public void Move(Movement movement)
    {
        if (!MyTurn)
            throw new NotYourTurnException();

        Position newPosition = CellOf(MyPosition).Move(movement);

        if (InvalidPosition(newPosition))
            throw new InvalidMovementException();

        MyPosition = newPosition;
        MyTurn = false;
    }

    private static IMapCell CellOf(Position newPosition)
        => Map.Single(c => c.Position.Equals(newPosition));

    private static bool InvalidPosition(Position newPosition)
        => newPosition.X < 0 || newPosition.X > MaxXPosition || newPosition.Y < 0 || newPosition.Y > MaxYPosition || CellOf(newPosition) is NoCell;

    private static Position MyRandomPosition()
        => new(RandomValue(MaxXPosition), RandomValue(MaxYPosition));

    private static int RandomValue(int maxValue)
        => new Random().Next(maxValue);

    private Position PreyRandomPosition()
    {
        int xDistance = new Random().Next(InitialDistance);
        int yDistance = InitialDistance - xDistance;
        int xPosition = CalculatePreyStartingCoordinate(xDistance, Axis.X);
        int yPosition = CalculatePreyStartingCoordinate(yDistance, Axis.Y);

        return new Position(xPosition, yPosition);
    }

    private int CalculatePreyStartingCoordinate(int distance, Axis axis)
    {
        int yPosition;
        int maxPosition = axis == Axis.X ? MaxXPosition : MaxYPosition;
        int myPosition = axis == Axis.X ? MyPosition.X : MyPosition.Y;

        if ((myPosition - distance) >= 0 && (myPosition + distance) <= maxPosition)
            yPosition = myPosition + RandomSign(distance);
        else if ((myPosition - distance) >= 0)
            yPosition = myPosition - distance;
        else
            yPosition = myPosition + distance;

        return yPosition;
    }

    private static int RandomSign(int xDistance)
        => new Random().Next(1).Equals(1) ? xDistance : -1 * xDistance;

    private static IMapCell[] GetMap()
        => new IMapCell[] {
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

        new DownUpCell(0, 5), new UpRightCell(1, 5), new DownUpCell(2, 5), new DownUpCell(3, 4), new DownUpCell(4, 5),
        new DownUpCell(5, 5), new NoCell(6, 5), new NoCell(7, 5), new NoCell(8, 4), new NoCell(9, 5),

        new DownUpCell(0, 6), new UpRightCell(1, 6), new LeftRightCell(2, 6), new AllDirectionCell(3, 6), new LeftRightCell(4, 6),
        new AllDirectionCell(5, 6), new LeftRightCell(6, 6), new AllDirectionCell(7, 6), new LeftRightCell(8, 6), new AllDirectionCell(9, 6),

        new UpRightCell(0, 7), new DownUpCell(1, 7), new DownUpCell(2, 7), new DownUpCell(3, 7), new DownUpCell(4, 7),
        new NoCell(5, 7), new NoCell(6, 7), new NoCell(7, 7), new NoCell(8, 7), new NoCell(9, 7),

        new UpRightCell(0, 8), new LeftRightCell(1, 8), new LeftRightCell(2, 8), new AllDirectionCell(3, 8), new LeftRightCell(4, 8),
        new AllDirectionCell(5, 8), new LeftRightCell(6, 8), new AllDirectionCell(7, 8), new LeftRightCell(8, 8), new AllDirectionCell(9, 8)
    };

    private static string MapOutput()
    {
        int index = 0;
        StringBuilder output = new();

        for (int i = 0; i <= MaxYPosition; i++) {
            for (int j = 0; j <= MaxXPosition; j++) {
                output.Append(Map[index].Symbol.ToString() + " ");
                index++;
            }
            output.AppendLine();
        }

        return output.ToString();
    }
}