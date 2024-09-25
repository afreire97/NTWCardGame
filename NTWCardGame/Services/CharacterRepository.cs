using NTWCardGame.Data;
using NTWCardGame.Models;

namespace NTWCardGame.Services
{
    public class CharacterRepository : ICharacterRepository
    {

        private readonly AppDbContext _db;
        public CharacterRepository(AppDbContext db)
        {
            this._db = db;
        }

        public IEnumerable<CharacterEntity> GetAll()
        {

            return _db.Characters.ToList();
        }

        public CharacterEntity GetCharacter(int id)
        {
            return _db.Characters.Find(id);

        }
    }
}
