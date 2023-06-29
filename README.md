# ProgrammersQuest

This console application project is a competition result of a trainee project. 
The goal was to create a text adventure game within a regular german work day (8 hours) which allows the player to
a) move through a automatically generated maze
b) discover hidden items, enemies or friendly creatures inside of automatically created areas
c) improve player power by collecting items
d) choose between (at least) two different area moves
e) fight (at least) one boss 

To make this code work you need .NET-Framework 4.8 or higher and an IDE for C#.


## Inclusions/Packages

The following packages and frameworks are included:
- Spectre.Console (0.46.1-preview.0.2)


## The story

You are software developer in a small team of 5 devs for a indie company. Work is exciting, deadlines are hard, customers are unforgivable in case of bugs ... business as usual.
Your next project is to refactor and rework and old project for a security department in the netherlands.
Your trainee Jan already tried his best in fixing and refactoring old code. Unfortunately his skills weren't enough to manage the spaghetti code ...
... for more: Play the game.

## How is the code organized

The program starts with Program.cs where the player is able to set a name, choose difficulty level and choose the amount of areas inside the maze. After reading the story the player is thrown into a GameRoutine where he/she can discover source code, interact with bugs (friendly or aggressive) and walk his/her way through the maze. In case of a battle the player is able to choose between attack and defense (highest value wins). At the end of the maze the player can fight the boss to win the game.

### Generating player

You can generate a player with following difficulty levels:
a) Easy
-> The player has base attack and base defense of 12. Base hp is 100
a) Medium
-> The player has base attack and base defense of 6. Base hp is 50
a) Hard
-> The player has base attack and base defense of 3. Base hp is 25
a) Impossible
-> The player has base attack and base defense of 1. Base hp is 1

### Generating maze

The algorithm of maze generation:
1. Generate first area
2. Generate a move for first area
3. Random: Generate new item for first area
4. Generate creature for first area
5. Generate new area
6. Generate a move from new area to previous area
7. Random: Generate new item for new area
8. IF(area is last area) -> Create boss for new area ELSE -> Create new creature for new area
9. IF(area is not last area) -> Generate a move to a new area
10. Try to generate a move to a random previous area (if not already existing)
11. Go to 5.

### Generating items

Inside ItemGenerator.cs there is a list of items which can be created while generating maze. It is a hardcoded list (feel free to add more to the list).

### Generating creatures

Inside CreatureGenerator.cs there are three lists of creatures (boss, friendly and enemies) which can be created while generating maze. They are a hardcoded lists (feel free to add more to the lists).

## Unit testing

Beside the "Programmers Quest"-project you can find a "Programmers Test"-project which includes unit tests for all generators. In case you are modifing the code the unit tests will tell you whether or not you broke the codes logic. 

## Copyright

Feel free to do whatever you want with the source code to make yourself or others happy. As long as you don't harm anybody inside your projects you are free to express yourself.
