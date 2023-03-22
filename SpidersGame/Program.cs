using Spiders;
using Spiders.Exceptions;

SpiderHuntingGameOrchestrator orchestrator = Setup();
PlayGame(orchestrator);
ShowFinalResult(orchestrator);

static SpiderHuntingGameOrchestrator Setup()
{
    Console.WriteLine("Welcome to Spiders Game! Let's play!");
    Console.WriteLine();

    return new SpiderHuntingGameOrchestrator();
}

static void PlayGame(SpiderHuntingGameOrchestrator orchestrator)
{
    do {
        PlayTurn(orchestrator);
    } while (!orchestrator.Finished);
}

static void PlayTurn(SpiderHuntingGameOrchestrator orchestrator)
{
    Console.WriteLine("**********************************************");
    Console.WriteLine("Current situation:");
    Console.WriteLine(orchestrator.Output);
    Console.WriteLine("**********************************************");
    Console.WriteLine();
    Console.WriteLine("Choose your next move (L, U, R, D):");
    ConsoleKeyInfo userInput = Console.ReadKey();
    Move(orchestrator, userInput);
}

static void Move(SpiderHuntingGameOrchestrator orchestrator, ConsoleKeyInfo userInput)
{
    try {
        switch (userInput.KeyChar) {
            case 'L':
                orchestrator.MoveMeAndPrey(SpiderHuntingGame.Movement.Left);
                break;
            case 'U':
                orchestrator.MoveMeAndPrey(SpiderHuntingGame.Movement.Up);
                break;
            case 'R':
                orchestrator.MoveMeAndPrey(SpiderHuntingGame.Movement.Right);
                break;
            case 'D':
                orchestrator.MoveMeAndPrey(SpiderHuntingGame.Movement.Down);
                break;
            default:
                Console.WriteLine($"Invalid command: {userInput.KeyChar}");
                break;
        }
    }
    catch (InvalidMovementException) {
        Console.WriteLine("Invalid move. Please, try again.");
    }
}

static void ShowFinalResult(SpiderHuntingGameOrchestrator orchestrator)
{
    Console.WriteLine();
    Console.WriteLine();

    if (orchestrator.Won)
        Console.WriteLine("Congrats!!! You won!!!");
    else
        Console.WriteLine("The prey did really a good job. Good luck next time!");
}