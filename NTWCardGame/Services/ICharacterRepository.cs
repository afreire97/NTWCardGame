using NTWCardGame.Models;

namespace NTWCardGame.Services
{
    public interface ICharacterRepository
    {


        public CharacterEntity GetCharacter(int id);
        public IEnumerable<CharacterEntity> GetAll();


    }
}
