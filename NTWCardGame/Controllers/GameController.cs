using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTWCardGame.Data;
using NTWCardGame.Domain.Battle;
using NTWCardGame.Domain.Cards.Player;
using NTWCardGame.Domain.GameLogic;
using NTWCardGame.Models;
using NTWCardGame.Services;

namespace NTWCardGame.Controllers
{
    public class GameController : Controller
    {
        private readonly ICharacterRepository _context;
        public GameController(ICharacterRepository context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult StartGame([FromBody] StartGameRequest request)
        {
            // Buscar el personaje en la base de datos
            var selectedCharacter = _context.GetCharacter(request.CharacterId);
            if (selectedCharacter == null)
            {
                return BadRequest("Personaje no encontrado");
            }

            // Crear la instancia del jugador
            var player =  Player.FromEntity(selectedCharacter);

            // Crear los enemigos iniciales para la batalla
            var enemies = new List<Enemy>
            {
                new Enemy { Id = 1, Name = "Goblin", Health = 50, AttackDmg = 5 },
                new Enemy { Id = 2, Name = "Orco", Health = 100, AttackDmg = 10 }
            };

            // Inicializar la batalla
            var battle = new Battle(player, enemies);

            // Guardar la batalla en la sesión
            HttpContext.Session.SetObject("CurrentBattle", battle);

            // Responder con éxito
            return Ok(new { success = true });
        }
    }

    // Clase para recibir la solicitud de inicio de partida
    public class StartGameRequest
    {
        public int CharacterId { get; set; }
    }
 

    }

