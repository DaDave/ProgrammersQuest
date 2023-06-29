using System;
using System.Threading;
using Programmers_Quest.Generators;
using Programmers_Quest.Models;
using Programmers_Quest.Models.Creatures;
using Spectre.Console;

namespace Programmers_Quest.Activities
{
    public static class MainMenu
    {
        public static string SetPlayerName()
        {
            var playerName = AnsiConsole.Prompt(
                new TextPrompt<string>("What's your [green]name[/], programmer?")
                    .PromptStyle("green")
                    .ValidationErrorMessage("[red]That's not a valid player name[/]")
                    .Validate(name =>
                    {
                        return name switch
                        {
                            "Jan" => ValidationResult.Error(
                                "[red]You are not allowed to have fun while you're working, Jan![/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));
            AnsiConsole.Clear();
            return playerName;
        }

        public static DifficultyEnum SetDifficulty()
        {
            while (true)
            {
                var difficulty = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Please choose your [green]difficulty level[/]:")
                        .PageSize(5)
                        .MoreChoicesText("[grey](Move up and down to reveal more difficulty levels)[/]")
                        .AddChoices("Easy", "Medium", "Hard", "Impossible"));

                switch (difficulty)
                {
                    case "Easy":
                        return DifficultyEnum.Easy;
                    case "Medium":
                        return DifficultyEnum.Medium;
                    case "Hard":
                        return DifficultyEnum.Hard;
                    case "Impossible":
                        return DifficultyEnum.Impossible;
                    default:
                        Console.Write("Invalid input. Please try again \n");
                        break;
                }
            }
        }

        public static int SetAreaAmount()
        {
            var areaAmount = AnsiConsole.Prompt(
                new TextPrompt<int>("Please choose [green]amount of areas[/] [grey](3-70)[/]:")
                    .PromptStyle("green")
                    .ValidationErrorMessage("[red]That's not a valid amount of areas[/]")
                    .Validate(amount =>
                    {
                        return amount switch
                        {
                            < 3 => ValidationResult.Error("[red]Area amount must be at least 3[/]"),
                            >= 99 => ValidationResult.Error("[red]Area amount must be less than 99[/]"),
                            _ => ValidationResult.Success(),
                        };
                    }));
            AnsiConsole.Clear();
            return areaAmount;
        }
        
        public static (Maze, Player) ProgressGeneration(string playerName,
            DifficultyEnum difficultyLevel, int areaAmount)
        {
            var maze = new Maze();
            var player = new Player();
            var mazeGenerateService = new MazeGenerator();
            var playerGenerateService = new PlayerGenerator();
            AnsiConsole.MarkupLine("[green]Generating game ...[/]");
            AnsiConsole.Status()
                .Spinner(Spinner.Known.Bounce)
                .Start("Progress...", ctx =>
                {
                    AnsiConsole.MarkupLine("[grey]Implement adventurer ...[/]");
                    player = PlayerGenerator.Generate(playerName, difficultyLevel);
                    Thread.Sleep(1000);

                    AnsiConsole.MarkupLine("[grey]Write code and inject bugs ...[/]");
                    AnsiConsole.MarkupLine("[grey]Hide items in code ...[/]");
                    AnsiConsole.MarkupLine("[grey]Distribute items to bugs ...[/]");
                    maze = mazeGenerateService.Generate(areaAmount);
                    Thread.Sleep(1000);

                    AnsiConsole.MarkupLine("[grey]Blame trainee for being careless ...[/]");
                    Thread.Sleep(1000);

                    AnsiConsole.MarkupLine("[grey]All set and done![/]");
                    Thread.Sleep(1000);
                });
            AnsiConsole.Clear();
            return (maze, player);
        }
    }
}