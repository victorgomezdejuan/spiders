using Spiders;

namespace SpidersTests;

public class Tests
{
    [Test]
    public void StartingDistance()
    {
        SpiderHuntingGame game = new();

        Assert.That(game.CurrentDistance, Is.EqualTo(2));
    }
}