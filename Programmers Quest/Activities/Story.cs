using System;
using System.Threading;
using Spectre.Console;

namespace Programmers_Quest.Activities
{
    public static class Story
    {
        public static void ShowStory(string playerName)
        {
            AnsiConsole.MarkupLine(
                "You are [green]software developer[/] in a [yellow]small team[/] of 5 devs for a in[red]die[/] company.");
            Console.ReadKey();
            AnsiConsole.MarkupLine(
                "Work is [green]exciting[/], deadlines are [blue]hard[/], customers are [grey]unforgivable[/] in case of [yellow]bugs[/] ... [purple]business as usual[/].");
            Console.ReadKey();
            AnsiConsole.MarkupLine(
                "Your next [yellow]project[/] is to [green]refactor and rework[/] and old project for a [blue]security department[/] in the [green]netherlands[/].");
            Console.ReadKey();
            AnsiConsole.MarkupLine(
                "Your trainee [red]Jan[/] already tried his best in [blue]fixing and refactoring[/] old code.");
            Console.ReadKey();
            AnsiConsole.MarkupLine(
                "Unfortunately his [grey]skills[/] weren't enough to manage the [red]spaghetti code[/] ...");
            Console.ReadKey();
            AnsiConsole.MarkupLine(
                "The [red]spaghetti code[/] tries to [green]prevent[/] Jan from cleaning the mess up.");
            Console.ReadKey();
            AnsiConsole.MarkupLine("[red]Spaghetti code[/] says ...");
            Console.ReadKey();
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[red]Spaghetti code[/] says '[grey]RElFRUVFRSBKQU4=[/]'");
            var hasToDecodeString = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Decode [grey]'RElFRUVFRSBKQU4='[/]?")
                    .AddChoices("1", "0"));
            AnsiConsole.Clear();
            if (hasToDecodeString == "1")
            {
                AnsiConsole.MarkupLine("Decoding ...");
                Thread.Sleep(1000);
                AnsiConsole.MarkupLine("Spaghetti code says ...");
                Thread.Sleep(1000);
                AnsiConsole.MarkupLine("[red]DIE JAN[/]");
                Console.ReadKey();
            }
            else
            {
                AnsiConsole.MarkupLine("Well then ...");
                Console.ReadKey();
            }

            AnsiConsole.MarkupLine("[grey]With a blink of an eye the spaghetti code devours Jan.[/]");
            Console.ReadKey();
            AnsiConsole.MarkupLine("Hurry up [red]" + playerName + "[/], you have to rescue your trainee!!!");
            Console.ReadKey();
            AnsiConsole.MarkupLine("This is your [red]programmer's quest[/]");
            AnsiConsole.MarkupLine("(Press any key to start the game)");
            Console.ReadKey();
        }
    }
}