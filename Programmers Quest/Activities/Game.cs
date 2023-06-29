using System;
using System.Collections.Generic;
using System.Linq;
using Programmers_Quest.Models;
using Programmers_Quest.Models.Creatures;
using Spectre.Console;

namespace Programmers_Quest.Activities
{
    public static class Game
    {
        private static readonly Random _random = new();
        public static bool PlayGameRoutine(Maze maze, Player player)
        {
            var actualArea = maze.Areas[0];
            var isGameOver = false;
            do
            {
                AnsiConsole.Clear();
                var choices = AddAreaChoices(maze, actualArea);
                var decision = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Your IDE displays [green]" + actualArea.Name + "[/]. ")
                        .AddChoices(choices));
                switch (decision)
                {
                    case "Investigate source code more closely":
                    {
                        var randomNumber = _random.Next(0, 3);
                        if (randomNumber == 0)
                        {
                            AnsiConsole.MarkupLine("You found [green]nothing suspicious[/].");
                            Console.ReadKey();
                            continue;
                        } 
                        if (randomNumber == 1)
                        {
                            if (actualArea.Items.Any())
                            {
                                var itemDecision = AnsiConsole.Prompt(
                                    new SelectionPrompt<string>()
                                        .Title("You found a [green]" + actualArea.Items.First().Name + "[/]. Would you like to pick it up?")
                                        .AddChoices("1", "0"));
                                if (itemDecision == "1")
                                {
                                    TransferItemFromAreaToPlayer(player, actualArea);
                                    Console.ReadKey();
                                }
                                continue;
                            }
                            AnsiConsole.MarkupLine("You found [green]nothing suspicious[/].");
                            Console.ReadKey();
                            continue;
                        }

                        if (IsNormalCreatureInActualArea(actualArea))
                        {
                            var creatureDecision = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("A [red]" + actualArea.Creatures.First().Name + "[/] appears. Would you like to interact with it?")
                                    .AddChoices("1", "0"));
                            if (creatureDecision == "1")
                            {
                                if (IsEnemyInActualArea(actualArea))
                                {
                                    var isVictorious = Battle.PlayBattleRoutine(player, actualArea.Creatures.First());
                                    if (isVictorious && HasCreatureAnItem(actualArea))
                                    {
                                        AnsiConsole.MarkupLine("You found a [green]" + actualArea.Creatures.First().Items.First().Name + "[/].");
                                        TransferItemFromCreatureToPlayer(player, actualArea);
                                        Console.ReadKey();
                                    }
                                    if (!isVictorious)
                                    {
                                        isGameOver = true;
                                    }
                                }
                                if (IsMateInActualArea(actualArea))
                                {
                                    if (HasCreatureAnItem(actualArea))
                                    {
                                        AnsiConsole.MarkupLine(actualArea.Creatures.First().Name + " is friendly and give you a [green]" + actualArea.Creatures.First().Items.First().Name + "[/].");
                                        TransferItemFromCreatureToPlayer(player, actualArea);
                                        Console.ReadKey();
                                        continue;
                                    }
                                    AnsiConsole.MarkupLine(actualArea.Creatures.First().Name + " is friendly and wishes you a good time.");
                                    Console.ReadKey();
                                    continue;
                                }
                            }
                            continue;
                        }
                        AnsiConsole.MarkupLine("You found [green]nothing suspicious[/].");
                        Console.ReadKey();
                        continue;
                    }
                    case "Fight final boss to save Jan":
                    {
                        if (actualArea.Creatures.First().CreatureType.Equals(CreatureType.Boss))
                        {
                            var isVictorious = Battle.PlayBattleRoutine(player, actualArea.Creatures.First());
                            if (isVictorious)
                            {
                                return true;
                            }
                        }
                        isGameOver = true;
                        break;
                    }
                }

                if (actualArea.Moves.Any(x => x.Name == decision))
                {
                    var nextAreaId = actualArea.Moves.Find(x => x.Name == decision).Id;
                    actualArea = maze.Areas[nextAreaId];
                }
            } while (!isGameOver);

            return false;
        }

        private static void TransferItemFromAreaToPlayer(Player player, Area actualArea)
        {
            player.Items.Add(actualArea.Items.First());
            AnsiConsole.MarkupLine("Your attack increased: [green]" + actualArea.Items.First().AttackModifier + "[/].");
            player.Attack += actualArea.Items.First().AttackModifier;
            AnsiConsole.MarkupLine("Your defense increased: [green]" + actualArea.Items.First().DefenseModifier + "[/].");
            player.Defense += actualArea.Items.First().DefenseModifier;
            actualArea.Items.RemoveAt(0);
        }

        private static void TransferItemFromCreatureToPlayer(Player player, Area actualArea)
        {
            player.Items.Add(actualArea.Creatures.First().Items.First());
            AnsiConsole.MarkupLine("Your attack increased: [green]" +
                                   actualArea.Creatures.First().Items.First().AttackModifier + "[/].");
            player.Attack += actualArea.Creatures.First().Items.First().AttackModifier;
            AnsiConsole.MarkupLine("Your defense increased: [green]" +
                                   actualArea.Creatures.First().Items.First().DefenseModifier + "[/].");
            player.Defense += actualArea.Creatures.First().Items.First().DefenseModifier;
            actualArea.Creatures.RemoveAt(0);
        }

        private static bool HasCreatureAnItem(Area actualArea)
        {
            return actualArea.Creatures.First().Items.Any();
        }

        private static bool IsMateInActualArea(Area actualArea)
        {
            return actualArea.Creatures.First().CreatureType.Equals(CreatureType.Mate);
        }

        private static bool IsEnemyInActualArea(Area actualArea)
        {
            return actualArea.Creatures.First().CreatureType.Equals(CreatureType.Enemy);
        }

        private static bool IsNormalCreatureInActualArea(Area actualArea)
        {
            return actualArea.Creatures.Any() && !actualArea.Creatures.First().CreatureType.Equals(CreatureType.Boss);
        }


        private static List<string> AddAreaChoices(Maze maze, Area actualArea)
        {
            var choices = actualArea.Moves.Select(x => x.Name).ToList();
            choices.Add("Investigate source code more closely");
            if (actualArea.Id == maze.Areas.Count - 1)
            {
                choices.Add("Fight final boss to save Jan");
            }
            return choices;
        }
    }
}