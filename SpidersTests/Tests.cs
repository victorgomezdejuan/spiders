using Spiders;

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
        SpiderHuntingGame game = new();

        game.Move();

        Assert.That(game.MyTurn, Is.False);
        Assert.Throws<InvalidActionException>(() => game.Move());
    }

    [Test]
    public void GetOutput()
    {
        SpiderHuntingGame game = new();
        string board = "/ - - O - O - O - O\r\n" +
            "/ | | | |\r\n| / - O - O - O - O\r\n" +
            "| / | | | |\r\nO - - O - O - O - O\r\n" +
            "| \\ | | | |\r\n" +
            "| \\ - O - O - O - O\r\n" +
            "\\ | | | |\r\n" +
            "\\ - - O - O - O - O";
        string positions = "My position:{0}, {1}\r\n" +
            "Prey's position: {2}, {3}";
        string parametrizedOutput = board + "\r\n\r\n" + positions;
        string expectedOutput = string.Format(parametrizedOutput,
            game.MyPosition.X, game.MyPosition.Y, game.PreyPosition.X, game.PreyPosition.Y);

        Assert.That(game.Output, Is.EqualTo(expectedOutput));
    }

    private static int DistanceBetween(Position myPosition, Position preyPosition)
        => Math.Abs(myPosition.X - preyPosition.X) + Math.Abs(myPosition.Y - preyPosition.Y);
}