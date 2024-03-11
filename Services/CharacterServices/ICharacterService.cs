using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services.CharacterServices
{
    public interface ICharacterService
    {
        IEnumerable<Character> GetCharacters();
        Character GetCharacter(int id);
        IEnumerable<Character> AddCharacter (Character newCharacter);

    }
}