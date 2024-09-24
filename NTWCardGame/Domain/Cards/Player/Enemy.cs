namespace NTWCardGame.Domain.Cards.Player
{
    public class Enemy : Character
    {
        public EnemyType Type { get; set; }
        public int Aggression { get; set; }

        public override void TakeDamage(int damage)
        {
            // Lógica específica para cuando el enemigo recibe daño
            // Por ejemplo, podría contraatacar o huir
        }

        public override void UseItem(Item item)
        {
            // Lógica específica para cuando el enemigo usa un objeto
            // Por ejemplo, usar una poción para curarse
        }

        
    }
}
