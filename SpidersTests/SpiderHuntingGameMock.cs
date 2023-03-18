using Spiders;

namespace SpidersTests;
internal class SpiderHuntingGameMock : SpiderHuntingGame
{
    public SpiderHuntingGameMock(Position myPosition, Position preyPosition) : base()
    {
        MyPosition = myPosition;
        PreyPosition = preyPosition;
    }
}
