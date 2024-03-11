using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Models;

namespace Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static IList<Character> personajes = new List<Character> {
            new Character {Name = "Manu", Id = 1},
            new Character {Name = "Luis", Id = 2},
            new Character {Name = "Xexu", Id = 3}
        };
        

        public IEnumerable<Character> AddCharacter(Character newCharacter)
        {
            personajes.Add(newCharacter);
            return personajes;
        }

        public IEnumerable<Character> GetAllCharacters()
        {
               return personajes; 
        }

        public Character GetCharacter(int id)
        {
            var character = personajes.FirstOrDefault(c => c.Id == id);

            if (character is not null)
                return character;
            
            throw new Exception("Character NOT found");
        }
    }
}