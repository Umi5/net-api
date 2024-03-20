using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Character
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Hitpoints { get; set; }
        public int Strenght { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RpgClass Class { get; set; }
        public Backpack? Backpack { get; set; }
    }

}