using NTWCardGame.Domain.Cards.Player;

namespace NTWCardGame.Domain.GameLogic
{
    public class Turn
    {
        public Character Attacker { get; set; }  // El que realiza la acción
        public Character Defender { get; set; }  // El que recibe la acción
        public bool IsPlayerTurn { get; set; }   // Indica si es el turno del jugador
        public int TurnOrder { get; set; }       // El orden del turno en la secuencia

        public Turn(Character attacker, Character defender, bool isPlayerTurn, int turnOrder)
        {
            Attacker = attacker;
            Defender = defender;
            IsPlayerTurn = isPlayerTurn;
            TurnOrder = turnOrder;
        }

        public void Execute()
        {
            if (IsPlayerTurn)
            {
                // Si es el turno del jugador, puede atacar o usar una habilidad
                Attacker.Attack(Defender);
            }
            else
            {
                // Si es el turno del enemigo, realiza su acción predeterminada
                Attacker.Attack(Defender);
            }
        }
    }
}
