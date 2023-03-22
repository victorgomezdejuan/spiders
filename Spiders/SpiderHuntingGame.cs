using Spiders.Cells;
using Spiders.Exceptions;

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

    private const int InitialDistance = 2;

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
        CellMap.MapOutput() + "\r\n" +
        "My position: {0}, {1}\r\n" +
        "Prey's position: {2}, {3}",
        MyPosition.X, MyPosition.Y, PreyPosition.X, PreyPosition.Y);

    public void MoveMe(Movement movement)
    {
        if (!MyTurn)
            throw new NotYourTurnException();

        Position newPosition = ApplyMovementToPosition(movement, MyPosition);

        if (InvalidPosition(newPosition))
            throw new InvalidMovementException();

        MyPosition = newPosition;
        MyTurn = false;
    }

    public void MovePrey()
    {
        if (MyTurn)
            throw new NotYourTurnException();

        Position currentPosition = PreyPosition;
        Position newPosition = CalculatePreyPotentialNewPosition();

        if (InvalidPreyPosition(newPosition))
            PreyPosition = currentPosition;
        else
            PreyPosition = newPosition;

        MyTurn = true;
    }

    private Position CalculatePreyPotentialNewPosition()
    {
        Position newPosition;
        List<Movement> possibleMovements = CellMap.CellOf(PreyPosition).PosibleMovements.ToList();

        do {
            int nextMovementIndex = new Random().Next(possibleMovements.Count - 1);
            newPosition = ApplyMovementToPosition(possibleMovements[nextMovementIndex], PreyPosition);
            possibleMovements.RemoveAt(nextMovementIndex);
        } while (possibleMovements.Count > 0 && InvalidPreyPosition(newPosition));

        return newPosition;
    }

    private static Position ApplyMovementToPosition(Movement movement, Position position)
    {
        if (!CellMap.CellOf(position).PosibleMovements.Contains(movement))
            throw new InvalidMovementException();

        return movement switch {
            Movement.Up => new(position.X, position.Y - 1),
            Movement.Down => new(position.X, position.Y + 1),
            Movement.Left => new(position.X - 1, position.Y),
            Movement.Right => new(position.X + 1, position.Y),
            _ => throw new InvalidMovementException(),
        };
    }

    private static bool InvalidPosition(Position newPosition)
        => newPosition.X < 0 ||
        newPosition.X > CellMap.MaxXPosition ||
        newPosition.Y < 0 ||
        newPosition.Y > CellMap.MaxYPosition ||
        CellMap.CellOf(newPosition) is NoCell;

    private bool InvalidPreyPosition(Position newPosition)
        => InvalidPosition(newPosition) || newPosition.Equals(MyPosition);

    private static Position MyRandomPosition()
        => new(RandomValue(CellMap.MaxXPosition), RandomValue(CellMap.MaxYPosition));

    private static int RandomValue(int maxValue)
        => new Random().Next(maxValue);

    private Position PreyRandomPosition()
    {
        Position newPosition;

        do {
            int xDistance = new Random().Next(InitialDistance);
            int yDistance = InitialDistance - xDistance;
            int xPosition = CalculatePreyStartingCoordinate(xDistance, Axis.X);
            int yPosition = CalculatePreyStartingCoordinate(yDistance, Axis.Y);
            newPosition = new Position(xPosition, yPosition);
        } while (CellMap.CellOf(newPosition) is NoCell);

        return newPosition;
    }

    private int CalculatePreyStartingCoordinate(int distance, Axis axis)
    {
        int yPosition;
        int maxPosition = axis == Axis.X ? CellMap.MaxXPosition : CellMap.MaxYPosition;
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
}