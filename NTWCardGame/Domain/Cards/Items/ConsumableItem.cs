namespace NTWCardGame.Domain.Cards.Items
{
    public abstract class ConsumableItem : Item
    {
        public Effects.Effect Effect { get; set; }

        public override void Use(Player.Player player)
        {
            Effect.Apply(player);
            // Eliminar el ítem del inventario si no es apilable
            if (!Stackable)
            {
                player.Inventory.Remove(this);
            }
        }
    }
}
