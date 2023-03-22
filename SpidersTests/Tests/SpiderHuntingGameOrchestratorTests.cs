using Spiders;
using Spiders.Exceptions;
using SpidersTests.Mocks;
using static Spiders.SpiderHuntingGame;

namespace SpidersTests.Tests;

internal class SpiderHuntingGameOrchestratorTests
{
    [Test]
    public void WinGame()
    {
        SpiderHuntingGameOrchestratorMock orchestrator = new(new(8, 0), new(9, 0));

        orchestrator.MoveMeAndPrey(Movement.Right);

        Assert.That(orchestrator.Finished, Is.True);
        Assert.That(orchestrator.Won, Is.True);
    }

    [Test]
    public void LoseGame()
    {
        SpiderHuntingGameOrchestratorMock orchestrator = new(new(7, 0), new(9, 0));

        orchestrator.SetTurn(9);
        orchestrator.MoveMeAndPrey(Movement.Right);

        Assert.That(orchestrator.Finished, Is.True);
        Assert.That(orchestrator.Won, Is.False);
    }

    [Test]
    public void TurnStartsInOne()
    {
        SpiderHuntingGameOrchestratorMock orchestrator = new();

        Assert.That(orchestrator.Turn, Is.EqualTo(1));
    }

    [Test]
    public void UpdateTurnInEveryMove()
    {
        SpiderHuntingGameOrchestratorMock orchestrator = new(new(0, 0), new(9, 0));

        Assert.That(orchestrator.Turn, Is.EqualTo(1));
        orchestrator.MoveMeAndPrey(Movement.Right);
        Assert.That(orchestrator.Turn, Is.EqualTo(2));
        orchestrator.MoveMeAndPrey(Movement.Right);
        Assert.That(orchestrator.Turn, Is.EqualTo(3));
    }

    [Test]
    public void FinishedGame_TryToMove()
    {
        SpiderHuntingGameOrchestratorMock orchestrator = new(new(8, 0), new(9, 0));

        orchestrator.MoveMeAndPrey(Movement.Right);

        Assert.That(orchestrator.Finished, Is.True);
        Assert.Throws<GameFinishedException>(() => orchestrator.MoveMeAndPrey(Movement.Left));
    }

    [Test]
    public void GetOuput()
    {
        SpiderHuntingGameOrchestrator orchestrator = new();

        Assert.That(orchestrator.Output, Is.Not.Empty);
    }
}
