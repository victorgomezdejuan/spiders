using Spiders;
using Spiders.Exceptions;
using static Spiders.SpiderHuntingGame;

namespace SpidersTests;

public class Tests
{
    [Test]
    public void StartingDistance()
    {
        SpiderHuntingGame game = new();

        Position myPosition = game.MyPosition;
        Position preyPosition = game.PreyPosition;

        Assert.That(DistanceBetween(myPosition, preyPosition), Is.EqualTo(2));
    }

    [Test]
    public void StartingPositionsAreRandom()
    {
        List<Position> myPositions = new();
        List<Position> preyPositions = new();

        for (int i = 0; i < 100; i++) {
            SpiderHuntingGame game = new();
            myPositions.Add(game.MyPosition);
            preyPositions.Add(game.PreyPosition);
        }

        Assert.That(myPositions.Distinct().Count, Is.GreaterThan(1));
        Assert.That(preyPositions.Distinct().Count, Is.GreaterThan(1));
    }

    [Test]
    public void ICanOnlyMoveInMyTurn()
    {
        SpiderHuntingGameMock game = new(new(0, 0), new(2, 2));

        game.Move(Movement.Right);

        Assert.That(game.MyTurn, Is.False);
        Assert.Throws<NotYourTurnException>(() => game.Move(Movement.Right));
    }

    [Test]
    public void GetOutput()
    {
        SpiderHuntingGame game = new();
        string map = "/ - - O - O - O - O \r\n" +
            "/ | | | |           \r\n" +
            "| / - O - O - O - O \r\n" +
            "| / | | | |         \r\n" +
            "O - - O - O - O - O \r\n" +
            "| \\ | | | |         \r\n" +
            "| \\ - O - O - O - O \r\n" +
            "\\ | | | |           \r\n" +
            "\\ - - O - O - O - O \r\n";
        string positions = "My position:{0}, {1}\r\n" +
            "Prey's position: {2}, {3}";
        string parametrizedOutput = map + "\r\n" + positions;
        string expectedOutput = string.Format(parametrizedOutput,
            game.MyPosition.X, game.MyPosition.Y, game.PreyPosition.X, game.PreyPosition.Y);

        Assert.That(game.Output, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void AllDirectionCell_MoveUp()
        => AssertMovement(3, 2, Movement.Up, 3, 1);

    [Test]
    public void AllDirectionCell_MoveRight()
        => AssertMovement(3, 2, Movement.Right, 4, 2);

    [Test]
    public void AllDirectionCell_MoveDown()
        => AssertMovement(3, 2, Movement.Down, 3, 3);

    [Test]
    public void AllDirectionCell_MoveLeft()
        => AssertMovement(3, 2, Movement.Left, 2, 2);

    [Test]
    public void DownRightCell_MoveDown()
        => AssertMovement(0, 0, Movement.Down, 0, 1);

    [Test]
    public void DownRightCell_MoveRight()
        => AssertMovement(0, 0, Movement.Right, 1, 0);

    [Test]
    public void DownRightCell_MoveUp()
        => AssertInvalidMovement(0, 1, Movement.Up);

    [Test]
    public void DownRightCell_MoveLeft()
        => AssertInvalidMovement(0, 1, Movement.Left);

    [Test]
    public void DownUpCell_MoveUp()
    => AssertMovement(1, 1, Movement.Up, 1, 0);

    [Test]
    public void DownUpCell_MoveRight()
        => AssertInvalidMovement(1, 1, Movement.Right);

    [Test]
    public void DownUpCell_MoveDown()
        => AssertMovement(1, 1, Movement.Down, 1, 2);

    [Test]
    public void DownUpCell_MoveLeft()
        => AssertInvalidMovement(1, 1, Movement.Left);

    [Test]
    public void LeftRightCell_MoveUp()
        => AssertInvalidMovement(2, 2, Movement.Up);

    [Test]
    public void LeftRightCell_MoveRight()
        => AssertMovement(2, 2, Movement.Right, 3, 2);

    [Test]
    public void LeftRightCell_MoveDown()
        => AssertInvalidMovement(2, 2, Movement.Down);

    [Test]
    public void LeftRightCell_MoveLeft()
        => AssertMovement(2, 2, Movement.Left, 1, 2);

    [Test]
    public void UpRightCell_MoveUp()
    => AssertMovement(1, 5, Movement.Up, 1, 4);

    [Test]
    public void UpRightCell_MoveRight()
        => AssertMovement(1, 5, Movement.Right, 2, 5);

    [Test]
    public void UpRightCell_MoveDown()
        => AssertInvalidMovement(1, 5, Movement.Down);

    [Test]
    public void UpRightCell_MoveLeft()
        => AssertInvalidMovement(1, 5, Movement.Left);

    private static int DistanceBetween(Position myPosition, Position preyPosition)
        => Math.Abs(myPosition.X - preyPosition.X) + Math.Abs(myPosition.Y - preyPosition.Y);

    private static void AssertMovement(int startingX, int startingY, Movement movement, int resultingX, int resultingY)
    {
        SpiderHuntingGameMock game = new(new(startingX, startingY), new(8, 9));

        game.Move(movement);

        Assert.That(game.MyPosition, Is.EqualTo(new Position(resultingX, resultingY)));
    }

    public static void AssertInvalidMovement(int startingX, int startingY, Movement movement)
    {
        SpiderHuntingGameMock game = new(new(startingX, startingY), new(8, 9));

        Assert.Throws<InvalidMovementException>(() => game.Move(movement));
    }
}