using Microsoft.AspNetCore.Mvc;
using NTWCardGame.Models;
using NTWCardGame.Services;

namespace NTWCardGame.Controllers.Character
{
    public class CharacterSelectionController : Controller
    {

        private readonly ICharacterRepository _rep;
        public CharacterSelectionController(ICharacterRepository rep)
        {
            this._rep = rep;
        }
        public IActionResult Index()
        {

            IEnumerable<CharacterEntity> availableCharacters = _rep.GetAll();


            return View(availableCharacters);
        }
    }
}
