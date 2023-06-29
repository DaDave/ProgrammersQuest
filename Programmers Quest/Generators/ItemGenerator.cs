using System;
using System.Collections.Generic;
using Programmers_Quest.Models;

namespace Programmers_Quest.Generators
{
    public class ItemGenerator
    {
        private readonly Random _random = new(Environment.TickCount);
        private readonly List<Item> _itemInventory = new()
        {
            new Item {Id = 0, Name = "Rubber duck", AttackModifier = 0, DefenseModifier = 1},
            new Item {Id = 1, Name = "Programming keyboard", AttackModifier = 2, DefenseModifier = 0},
            new Item {Id = 2, Name = "Programming mouse", AttackModifier = 2, DefenseModifier = 0},
            new Item {Id = 3, Name = "Wired headset", AttackModifier = 1, DefenseModifier = 1},
            new Item {Id = 4, Name = "Wireless headset", AttackModifier = 2, DefenseModifier = 2},
            new Item {Id = 5, Name = "Regular keyboard", AttackModifier = 1, DefenseModifier = 0},
            new Item {Id = 6, Name = "Regular mouse", AttackModifier = 1, DefenseModifier = 0},
            new Item {Id = 7, Name = "Gaming keyboard", AttackModifier = 3, DefenseModifier = 0},
            new Item {Id = 8, Name = "Gaming mouse", AttackModifier = 3, DefenseModifier = 0},
            new Item {Id = 9, Name = "Gaming headset", AttackModifier = 3, DefenseModifier = 3},
            new Item {Id = 10, Name = "Programming notebook", AttackModifier = 4, DefenseModifier = 2},
            new Item {Id = 11, Name = "Gaming notebook", AttackModifier = 6, DefenseModifier = 3},
            new Item {Id = 12, Name = "Planning poker", AttackModifier = 0, DefenseModifier = 2},
            new Item {Id = 13, Name = "Regular notebook", AttackModifier = 2, DefenseModifier = 1},
            new Item {Id = 14, Name = "Pen and paper", AttackModifier = 0, DefenseModifier = 2},
            new Item {Id = 15, Name = "Book 'Clean Code'", AttackModifier = 2, DefenseModifier = 2},
            new Item {Id = 16, Name = "Book 'Refactoring'", AttackModifier = 4, DefenseModifier = 0},
            new Item {Id = 17, Name = "Book 'Design Pattern'", AttackModifier = 0, DefenseModifier = 4},
            new Item {Id = 18, Name = "Book 'Programming for Dummies'", AttackModifier = 1, DefenseModifier = 1},
            new Item {Id = 19, Name = "Regular chair", AttackModifier = 0, DefenseModifier = 1},
            new Item {Id = 20, Name = "Gaming chair", AttackModifier = 0, DefenseModifier = 3},
            new Item {Id = 21, Name = "Regular table", AttackModifier = 0, DefenseModifier = 1},
            new Item {Id = 22, Name = "Gaming table", AttackModifier = 0, DefenseModifier = 3},
        };
        
        public Item Generate()
        {
            if (_itemInventory.Count <= 0)
            {
                return null;
            }
            var randomListIndex = _random.Next(0, _itemInventory.Count - 1);
            var randomItem = _itemInventory[randomListIndex];
            _itemInventory.RemoveAt(randomListIndex);
            return randomItem;
        }
    }
}