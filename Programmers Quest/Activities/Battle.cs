using System;
using Programmers_Quest.Models;
using Programmers_Quest.Models.Creatures;
using Spectre.Console;

namespace Programmers_Quest.Activities
{
    public static class Battle
    {
        private static readonly Random _random = new();
        
        public static bool PlayBattleRoutine(Player player, Creature creature)
        {
            AnsiConsole.MarkupLine("[red]The fight begins![/]");
            Console.ReadKey();
            while (player.Hp > 0 && creature.Hp > 0)
            {
                var (playerDecision, creatureDecision) = InputTurnDecisions(player, creature);
                var hpLoss = 0;
                if (playerDecision == TurnDecisionEnum.Attack && creatureDecision == TurnDecisionEnum.Attack)
                {
                    if (player.Attack > creature.Attack)
                    {
                        hpLoss = player.Attack - creature.Attack;
                        creature.Hp -= hpLoss;
                        AnsiConsole.MarkupLine(creature.Name + " loses " + hpLoss + " HP.");
                        Console.ReadKey();
                    } 
                    if (player.Attack == creature.Attack)
                    {
                        AnsiConsole.MarkupLine("Tie! Nothing happens.");
                        Console.ReadKey();
                    } 
                    if (player.Attack < creature.Attack)
                    {
                        hpLoss = creature.Attack - player.Attack;
                        player.Hp -= hpLoss;
                        AnsiConsole.MarkupLine("You lose " + hpLoss + " HP.");
                        Console.ReadKey();
                    } 
                }
                if (playerDecision == TurnDecisionEnum.Attack && creatureDecision == TurnDecisionEnum.Defense)
                {
                    if (player.Attack > creature.Defense)
                    {
                        hpLoss = player.Attack - creature.Defense;
                        creature.Hp -= hpLoss;
                        AnsiConsole.MarkupLine(creature.Name + " loses " + hpLoss + " HP.");
                        Console.ReadKey();
                    } 
                    if (player.Attack == creature.Defense)
                    {
                        AnsiConsole.MarkupLine("Tie! Nothing happens.");
                        Console.ReadKey();
                    } 
                    if (player.Attack < creature.Defense)
                    {
                        hpLoss = creature.Defense - player.Attack;
                        player.Hp -= hpLoss;
                        AnsiConsole.MarkupLine("You lose " + hpLoss + " HP.");
                        Console.ReadKey();
                    } 
                }
                if (playerDecision == TurnDecisionEnum.Defense && creatureDecision == TurnDecisionEnum.Attack)
                {
                    if (player.Defense > creature.Attack)
                    {
                        hpLoss = player.Defense - creature.Attack;
                        creature.Hp -= hpLoss;
                        AnsiConsole.MarkupLine(creature.Name + " loses " + hpLoss + " HP.");
                        Console.ReadKey();
                    } 
                    if (player.Defense == creature.Defense)
                    {
                        AnsiConsole.MarkupLine("Tie! Nothing happens.");
                        Console.ReadKey();
                    } 
                    if (player.Defense < creature.Attack)
                    {
                        hpLoss = creature.Attack - player.Defense;
                        player.Hp -= hpLoss;
                        AnsiConsole.MarkupLine("You lose " + hpLoss + " HP.");
                        Console.ReadKey();
                    } 
                }
                if (playerDecision == TurnDecisionEnum.Defense && creatureDecision == TurnDecisionEnum.Defense)
                {
                    if (player.Defense == creature.Defense)
                    {
                        AnsiConsole.MarkupLine("Both are defending ... Nothing happens.");
                        Console.ReadKey();
                    } 
                }
            }

            if (player.Hp <= 0)
            {
                AnsiConsole.MarkupLine("You lost!");
                Console.ReadKey();
                return false;
            }
            AnsiConsole.MarkupLine("You won!");
            Console.ReadKey();
            return true;
        }

        private static (TurnDecisionEnum, TurnDecisionEnum) InputTurnDecisions(Player player, Creature creature)
        {
            var playerDecisionString = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Your turn: Attack(" + player.Attack + ") or defense(" + player.Defense + ")?")
                    .AddChoices("Attack", "Defense"));
            var creatureDecisionString = _random.Next(0, 2) == 0 ? "Attack" : "Defense";
            AnsiConsole.MarkupLine(creature.Name + " chooses '" + creatureDecisionString + "'(" +
                                   (creatureDecisionString == "Attack" ? creature.Attack : creature.Defense) + ").");
            var playerDecision = playerDecisionString switch
            {
                "Attack" => TurnDecisionEnum.Attack,
                "Defense" => TurnDecisionEnum.Defense,
                _ => TurnDecisionEnum.Attack
            };
            var creatureDecision = creatureDecisionString switch
            {
                "Attack" => TurnDecisionEnum.Attack,
                "Defense" => TurnDecisionEnum.Defense,
                _ => TurnDecisionEnum.Attack
            };

            return (playerDecision, creatureDecision);
        }
    }
}