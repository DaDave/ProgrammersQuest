using System;
using System.Collections.Generic;
using Programmers_Quest.Models;
using Programmers_Quest.Models.Creatures;

namespace Programmers_Quest.Generators
{
    public class PlayerGenerator
    {
        public static Player Generate(string playerName, DifficultyEnum difficulty)
        {
            var player = new Player {Id = 0, Name = playerName, Items = new List<Item>()};
            switch (difficulty)
            {
                case DifficultyEnum.Easy:
                    player.Attack = 12;
                    player.Defense = 12;
                    player.Hp = 100;
                    break;
                case DifficultyEnum.Medium:
                    player.Attack = 6;
                    player.Defense = 6;
                    player.Hp = 50;
                    break;
                case DifficultyEnum.Hard:
                    player.Attack = 3;
                    player.Defense = 3;
                    player.Hp = 25;
                    break;
                case DifficultyEnum.Impossible:
                    player.Attack = 1;
                    player.Defense = 1;
                    player.Hp = 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, "Difficulty level not set.");
            }
            return player;
        }
    }
}