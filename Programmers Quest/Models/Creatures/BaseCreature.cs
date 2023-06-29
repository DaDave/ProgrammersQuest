using System.Collections.Generic;

namespace Programmers_Quest.Models.Creatures
{
    public abstract class BaseCreature
    {
        protected BaseCreature()
        {
            Items = new List<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public List<Item> Items { get; set; }
    }
}