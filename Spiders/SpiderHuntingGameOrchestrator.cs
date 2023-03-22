using Spiders.Exceptions;
using static Spiders.SpiderHuntingGame;

namespace Spiders;

public class SpiderHuntingGameOrchestrator
{
    private const int MaxTurns = 10;

    public SpiderHuntingGameOrchestrator()
    {
        Game = new();
        Turn = 1;
    }

    protected SpiderHuntingGame Game { get; init; }

    public bool Finished { get; private set; }

    public bool Won { get; private set; }

    public int Turn { get; protected set; }

    public string Output => Game.Output;

    public void MoveMeAndPrey(Movement movement)
    {
        if (Finished)
            throw new GameFinishedException();

        MoveMe(movement);

        if (!Finished)
            Game.MovePrey();
    }

    private void MoveMe(Movement movement)
    {
        Game.MoveMe(movement);
        Turn++;

        if (Game.MyPosition.Equals(Game.PreyPosition)) {
            Finished = true;
            Won = true;
        }
        else if (Turn == MaxTurns)
            Finished = true;
    }
}
