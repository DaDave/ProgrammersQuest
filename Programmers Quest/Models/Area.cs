using System.Collections.Generic;
using Programmers_Quest.Models.Creatures;

namespace Programmers_Quest.Models
{
    public class Area
    {
        public Area()
        {
            Moves = new List<Move>();
            Items = new List<Item>();
            Creatures = new List<Creature>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Move> Moves { get; set; }
        public List<Item> Items { get; set; }
        public List<Creature> Creatures { get; set; }
    }
}