using NTWCardGame.Domain.Cards.Player;
using System.Collections.Generic;
using System.Linq;

namespace NTWCardGame.Domain.Battle
{
    public class Battle
    {
        public Player Player { get; private set; }
        public List<Enemy> Enemies { get; private set; }
        private int currentTurnIndex;
        private List<Character> turnOrder;
        public List<BattleLogEntry> BattleLog { get; private set; } // Agregar log de batalla


        public Battle(Player player, List<Enemy> enemies)
        {
            Player = player;
            Enemies = enemies;
            currentTurnIndex = 0;

            // Inicializa el orden de los turnos (jugador primero, luego enemigos)
            turnOrder = new List<Character> { player };
            turnOrder.AddRange(enemies);
            BattleLog = new List<BattleLogEntry>(); // Inicializa el log

        }

        // Devuelve la información del turno actual
        public TurnInfo GetCurrentTurnInfo()
        {
            var currentCharacter = turnOrder[currentTurnIndex];
            return new TurnInfo
            {
                CurrentCharacter = currentCharacter,
                IsPlayerTurn = currentCharacter == Player,
                Player = Player,
                Enemies = Enemies
            };
        }

        // Comprueba si es el turno del jugador
        public bool IsPlayerTurn()
        {
            return turnOrder[currentTurnIndex] == Player;
        }

        // Ejecutar la acción del jugador y avanzar el turno
        public void ExecutePlayerAction(string actionType, int targetId)
        {
            if (!IsPlayerTurn())
            {
                throw new InvalidOperationException("No es el turno del jugador.");
            }

            Enemy target = GetCharacterById(targetId);
            int damage = 0;

            // Procesa la acción del jugador
            switch (actionType.ToLower())
            {
                case "attack":
                    damage = Player.Attack(target);
                    AddLogEntry($"El jugador atacó a {target.Name} y causó {damage} puntos de daño.");
                    break;
                // Agregar otros casos para habilidades o uso de objetos
                default:
                    throw new ArgumentException("Tipo de acción no válido.");
            }

            AdvanceTurn();
        }

        // Ejecuta los turnos de los enemigos
        public void ExecuteEnemyTurns()
        {
            int damage = 0;
            while (!IsPlayerTurn())
            {
                var currentEnemy = turnOrder[currentTurnIndex] as Enemy;
                if (currentEnemy != null && currentEnemy.Health > 0)
                {
                    // Los enemigos atacan al jugador en su turno
                     damage = currentEnemy.Attack(Player);
                    AddLogEntry($"{currentEnemy.Name} atacó al jugador y causó {damage} puntos de daño.");
                }
                AdvanceTurn();
            }
        }
        private void AddLogEntry(string message)
        {
            BattleLog.Add(new BattleLogEntry
            {
                Turn = currentTurnIndex + 1, // Turnos empiezan desde 1
                Message = message
            });
        }

        // Avanzar el turno al siguiente personaje
        private void AdvanceTurn()
        {
            currentTurnIndex = (currentTurnIndex + 1) % turnOrder.Count;

            // Si todos los enemigos han sido derrotados, termina la batalla
            if (Enemies.All(e => e.Health <= 0))
            {
                EndBattle();
            }
            if (Player.Health <= 0)
            {
                EndBattle();

            }
        }

        // Recuperar un personaje por ID
        public Enemy GetCharacterById(int id)
        {
         
            return Enemies.FirstOrDefault(e => e.Id == id);
        }

        // Método para finalizar la batalla
        private void EndBattle()
        {
            // Implementar lógica para terminar la batalla, como recompensas, experiencia, etc.
            Console.WriteLine("¡La batalla ha terminado!");
        }

        public bool IsBattleOver()
        {
            return IsVictory() || IsDefeat();
        }

        public bool IsVictory()
        {
            // Victoria si todos los enemigos han sido derrotados
            return Enemies.All(enemy => enemy.Health <= 0);
        }

        public bool IsDefeat()
        {
            // Derrota si el jugador ha sido derrotado
            return Player.Health <= 0;
        }
    }

    // Clase para representar la información del turno actual
    public class TurnInfo
    {
        public Character CurrentCharacter { get; set; }
        public bool IsPlayerTurn { get; set; }
        public Player Player { get; set; }
        public List<Enemy> Enemies { get; set; }
    }
    public class BattleLogEntry
    {
        public int Turn { get; set; }
        public string Message { get; set; }
    }
}
