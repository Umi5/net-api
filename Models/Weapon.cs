using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Weapon
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Character? Character { get; set; }
        public Guid CharacterId { get; set; }
    }
}