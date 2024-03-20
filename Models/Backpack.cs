using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Backpack
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid CharacterId { get; set; }
    }
}