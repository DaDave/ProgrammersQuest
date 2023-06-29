using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Programmers_Quest.Activities;
using Programmers_Quest.Models;
using Programmers_Quest.Models.Creatures;
using Spectre.Console;

namespace Programmers_Quest
{
    internal class Program
    {
        public static void Main()
        {
            AnsiConsole.Markup("Welcome to [underline red]A Programmers Quest[/]\n");
            
            var playerName = MainMenu.SetPlayerName();
            var difficultyLevel = MainMenu.SetDifficulty();
            var areaAmount = MainMenu.SetAreaAmount();
            var (maze, player) = MainMenu.ProgressGeneration(playerName, difficultyLevel, areaAmount);

            Story.ShowStory(player.Name);
            
            var isSuccessful = Game.PlayGameRoutine(maze, player);
            AnsiConsole.MarkupLine(isSuccessful
                ? "You did it! [green]You saved Jan![/]. Good job. The (programming) world is safe again."
                : "Game over. [green]You and Jan[/] are lost in the void ... FOREVER!");
            Console.ReadKey();
        }
    }
}