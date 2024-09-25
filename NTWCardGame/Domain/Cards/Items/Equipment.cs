using Mono.TextTemplating;

namespace NTWCardGame.Domain.Cards.Items
{
    public abstract class Equipment : Item
    {
        public EquipmentSlot Slot { get; set; }
        public Dictionary<Player.Stat, int> Bonuses { get; set; }

        public override void Use(Player.Player player)
        {
            // Equipar el ítem
            player.EquipItem(this);
        }
    }
}
