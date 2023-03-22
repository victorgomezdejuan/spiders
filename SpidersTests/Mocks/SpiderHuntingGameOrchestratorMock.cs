using Spiders;

namespace SpidersTests.Mocks;

internal class SpiderHuntingGameOrchestratorMock : SpiderHuntingGameOrchestrator
{
    public SpiderHuntingGameOrchestratorMock()
        => Game = new SpiderHuntingGame();

    public SpiderHuntingGameOrchestratorMock(Position myPosition, Position preyPosition)
        => Game = new SpiderHuntingGameMock(myPosition, preyPosition);

    internal void SetTurn(int value) => Turn = value;
}