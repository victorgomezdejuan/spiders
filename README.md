# Arithmetics
Kata got from https://www.codurance.com/katalyst/spiders.

Developed with dotnet (c#) and Visual Studio.

## Practice objectives
- TDD
- Simple design

## Brief explanation
### Requirements
Create a turn-based application where our spider will chase another spider.
We have 10 moves to catch our prey, if we fail, our spider dies.

On each turn we will control the spider and pass it a command that orders it where to move to, out of bound moves are not allowed as we should only move within the map.

The map should be printed at each turn so we can see how the game is developing.

### Rules
- The starting distance between our spider and our prey is 2 spaces.
- The starting positions can be random.
- Each spider can only move on their turn.
- Each spider has to follow the existing paths, no new paths can be created.
- We have 10 turns to play.
- If our spider catches its prey, the game ends and we win.
- If our spider fails to catch its prey, the game ends and we lose.