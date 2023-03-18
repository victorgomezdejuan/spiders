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
    public void DownRightCell_MoveDown()
    {
        SpiderHuntingGameMock game = new(new(0, 0), new(2, 2));

        game.Move(Movement.Down);

        Assert.That(game.MyPosition, Is.EqualTo(new Position(0, 1)));
    }

    [Test]
    public void DownRightCell_MoveRight()
    {
        SpiderHuntingGameMock game = new(new(0, 0), new(2, 2));

        game.Move(Movement.Right);

        Assert.That(game.MyPosition, Is.EqualTo(new Position(1, 0)));
    }

    [Test]
    public void DownRightCell_MoveUp()
    {
        SpiderHuntingGameMock game = new(new(0, 1), new(2, 2));

        Assert.Throws<InvalidMovementException>(() => game.Move(Movement.Up));
    }

    [Test]
    public void DownRightCell_MoveLeft()
    {
        SpiderHuntingGameMock game = new(new(0, 1), new(2, 2));

        Assert.Throws<InvalidMovementException>(() => game.Move(Movement.Left));
    }

    [Test]
    public void UpRightCell_MoveUp()
    {
        SpiderHuntingGameMock game = new(new(1, 5), new(2, 2));

        game.Move(Movement.Up);

        Assert.That(game.MyPosition, Is.EqualTo(new Position(1, 4)));
    }

    private static int DistanceBetween(Position myPosition, Position preyPosition)
        => Math.Abs(myPosition.X - preyPosition.X) + Math.Abs(myPosition.Y - preyPosition.Y);
}