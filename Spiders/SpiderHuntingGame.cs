namespace Spiders;
public class SpiderHuntingGame
{
    private const int MaxXPosition = 9;
    private const int MaxYPosition = 8;
    private const int InitialDistance = 2;

    public SpiderHuntingGame()
    {
        MyPosition = MyRandomPosition();
        PreyPosition = PreyRandomPosition();
        MyTurn = true;
    }

    public Position MyPosition { get; }
    public Position PreyPosition { get; }
    public bool MyTurn { get; private set; }
    public string Output => string.Format(
        "/ - - O - O - O - O\r\n" +
        "/ | | | |\r\n| / - O - O - O - O\r\n" +
        "| / | | | |\r\nO - - O - O - O - O\r\n" +
        "| \\ | | | |\r\n" +
        "| \\ - O - O - O - O\r\n" +
        "\\ | | | |\r\n" +
        "\\ - - O - O - O - O\r\n\r\n" +
        "My position:{0}, {1}\r\n" +
        "Prey's position: {2}, {3}",
        MyPosition.X, MyPosition.Y, PreyPosition.X, PreyPosition.Y);

    public void Move()
    {
        if (!MyTurn)
            throw new InvalidActionException();

        MyTurn = false;
    }

    private static Position MyRandomPosition()
        => new(RandomValue(MaxXPosition), RandomValue(MaxYPosition));

    private static int RandomValue(int maxValue)
        => new Random().Next(maxValue);

    private Position PreyRandomPosition()
    {
        int xPosition, yPosition;
        int xDistance = new Random().Next(InitialDistance);
        int yDistance = InitialDistance - xDistance;

        xPosition =
            MyPosition.X >= xDistance ?
            MyPosition.X + RandomSign(xDistance) : MyPosition.X + xDistance;
        yPosition =
            MyPosition.Y >= yDistance ?
            MyPosition.Y + RandomSign(yDistance) : MyPosition.X + yDistance;

        return new Position(xPosition, yPosition);
    }

    private static int RandomSign(int xDistance)
        => new Random().Next(1).Equals(1) ? xDistance : -1 * xDistance;
}