namespace NTWCardGame.Controllers
{
    using global::NTWCardGame.Domain.Battle;
    using global::NTWCardGame.Domain.GameLogic;
    using Microsoft.AspNetCore.Mvc;

    namespace NTWCardGame.Controllers
    {
        public class BattleController : Controller
        {
            // Muestra la vista de la batalla con el estado actual
            [HttpGet]
            public IActionResult Index()
            {
                var battle = HttpContext.Session.GetObject<Battle>("CurrentBattle");
                if (battle == null)
                {
                    return RedirectToAction("CharacterSelection", "Character"); // Si no hay batalla iniciada, volver a selección
                }

                return View(battle);
            }

            // Obtiene el estado actual del turno para la UI
            [HttpGet]
            public IActionResult GetCurrentTurn()
            {
                var battle = HttpContext.Session.GetObject<Battle>("CurrentBattle");
                if (battle == null)
                {
                    return BadRequest("No se ha iniciado una partida.");
                }

                return Ok(new
                {
                    player = new
                    {
                        health = battle.Player.Health,
                        mana = battle.Player.Mana
                    },
                    enemies = battle.Enemies.Select(e => new
                    {
                        id = e.Id,
                        name = e.Name,
                        health = e.Health
                    }),
                    turnInfo = battle.GetCurrentTurnInfo()
                });
            }

            // Procesa la acción del jugador
            [HttpPost]
            public IActionResult PlayerAction([FromBody] PlayerActionRequest actionRequest)
            {
                var battle = HttpContext.Session.GetObject<Battle>("CurrentBattle");
                if (battle == null)
                {
                    return BadRequest("No se ha iniciado una partida.");
                }

                if (!battle.IsPlayerTurn())
                {
                    return BadRequest("No es el turno del jugador.");
                }

                // Ejecuta la acción del jugador (por ejemplo, un ataque)
                battle.ExecutePlayerAction(actionRequest.ActionType, actionRequest.TargetId);

                // Ejecuta los turnos de los enemigos
                battle.ExecuteEnemyTurns();

                // Guarda el estado actualizado de la batalla
                HttpContext.Session.SetObject("CurrentBattle", battle);

                // Retorna el estado actualizado de la batalla
                return Ok(new
                {
                    player = new
                    {
                        health = battle.Player.Health,
                        mana = battle.Player.Mana
                    },
                    enemies = battle.Enemies.Select(e => new
                    {
                        id = e.Id,
                        name = e.Name,
                        health = e.Health
                    }),
                    turnInfo = battle.GetCurrentTurnInfo()
                });
            }
        }

        // Clase para representar la solicitud de acción del jugador
        public class PlayerActionRequest
        {
            public string ActionType { get; set; }
            public int TargetId { get; set; }
        }
    }

}
