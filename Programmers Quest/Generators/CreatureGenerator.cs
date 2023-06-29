using System;
using System.Collections.Generic;
using Programmers_Quest.Models;
using Programmers_Quest.Models.Creatures;

namespace Programmers_Quest.Generators
{
    public class CreatureGenerator
    {
        private readonly Random _random = new(Environment.TickCount);
        private readonly ItemGenerator _itemGenerator = new();
        private readonly List<Creature> _bossCreatureBox = new()
        {
            new Creature {Id = 0, Name = "Firewall dragon", Hp = 40, Attack = 15, Defense = 10, CreatureType = CreatureType.Boss},
            new Creature {Id = 1, Name = "King bug", Hp = 43, Attack = 10, Defense = 12, CreatureType = CreatureType.Boss},
            new Creature {Id = 2, Name = "Endless void", Hp = 42, Attack = 12, Defense = 11, CreatureType = CreatureType.Boss},
            new Creature {Id = 3, Name = "Giant virus", Hp = 30, Attack = 18, Defense = 17, CreatureType = CreatureType.Boss},
        };

        private readonly List<Creature> _regularCreatureBox = new()
        {
            new Creature
                {Id = 4, Name = "Small bug", Hp = 5, Attack = 1, Defense = 2, CreatureType = CreatureType.Enemy},
            new Creature
                {Id = 5, Name = "Bigger bug", Hp = 10, Attack = 2, Defense = 4, CreatureType = CreatureType.Enemy},
            new Creature
            {
                Id = 6, Name = "Endless while loop", Hp = 8, Attack = 0, Defense = 5, CreatureType = CreatureType.Enemy
            },
            new Creature
                {Id = 7, Name = "foreacher", Hp = 8, Attack = 5, Defense = 0, CreatureType = CreatureType.Enemy},
            new Creature
                {Id = 8, Name = "Angry integer", Hp = 9, Attack = 3, Defense = 3, CreatureType = CreatureType.Enemy},
            new Creature
                {Id = 9, Name = "Little boolean", Hp = 1, Attack = 1, Defense = 0, CreatureType = CreatureType.Enemy},
            new Creature
            {
                Id = 10, Name = "Evil switch-case", Hp = 6, Attack = 2, Defense = 1, CreatureType = CreatureType.Enemy
            },
            new Creature
                {Id = 11, Name = "Weird if", Hp = 7, Attack = 2, Defense = 2, CreatureType = CreatureType.Enemy},
            new Creature
            {
                Id = 12, Name = "Dangerous for loop", Hp = 3, Attack = 4, Defense = 3, CreatureType = CreatureType.Enemy
            },
            new Creature
                {Id = 13, Name = "Confused Object", Hp = 5, Attack = 3, Defense = 4, CreatureType = CreatureType.Enemy},
            new Creature
            {
                Id = 14, Name = "Crazy class definition", Hp = 3, Attack = 3, Defense = 5,
                CreatureType = CreatureType.Enemy
            },
            new Creature
                {Id = 15, Name = "Edgy Enum", Hp = 2, Attack = 2, Defense = 2, CreatureType = CreatureType.Enemy}
        };
            private readonly List<Creature> _friendlyCreatureBox = new()
            {
            new Creature {Id = 16, Name = "Ancient const", Hp = 15, Attack = 0, Defense = 3, CreatureType=CreatureType.Mate},
            new Creature {Id = 17, Name = "Code monkey", Hp = 10, Attack = 4, Defense = 0, CreatureType=CreatureType.Mate},
            new Creature {Id = 18, Name = "Echo of the database", Hp = 18, Attack = 2, Defense = 6, CreatureType=CreatureType.Mate},
            new Creature {Id = 19, Name = "Strange configuration", Hp = 5, Attack = 10, Defense = 3, CreatureType=CreatureType.Mate},
        };
        
        
        public Creature Generate(CreatureType creatureType)
        {
            Creature randomCreature;
            Item creatureItem;
            int randomListIndex;
            if (creatureType == CreatureType.Boss)
            {
                randomListIndex = _random.Next(0, _bossCreatureBox.Count - 1);
                randomCreature = _bossCreatureBox[randomListIndex];
                creatureItem = _itemGenerator.Generate();
                if (creatureItem != null)
                {
                    randomCreature.Items.Add(creatureItem);
                }
                return randomCreature;
            }
            if (creatureType == CreatureType.Mate)
            {
                randomListIndex = _random.Next(0, _friendlyCreatureBox.Count - 1);
                randomCreature = _friendlyCreatureBox[randomListIndex];
                return randomCreature;
            }
            randomListIndex = _random.Next(0, _regularCreatureBox.Count - 1);
            randomCreature = _regularCreatureBox[randomListIndex];
            creatureItem = _itemGenerator.Generate();
            if (creatureItem != null)
            {
                randomCreature.Items.Add(creatureItem);
            }
            return randomCreature;
        }
    }
}