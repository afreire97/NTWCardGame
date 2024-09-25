using NTWCardGame.Domain.Cards.Player;

namespace NTWCardGame.Domain.Cards.Items
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        //public Rarity Rarity { get; set; } // Rareza del ítem (común, raro, épico, etc.)
        public int Value { get; set; } // Valor del ítem en oro o puntos
        public bool Stackable { get; set; } // Indica si el ítem se puede apilar

        public virtual void Use(Player.Player player)
        {
            // Lógica por defecto para usar el ítem
            // Puede ser sobreescrita en subclases
            Console.WriteLine($"Usando {Name}");

        }

        public enum ItemType
        {
            Consumable,
            Equipment,
            // ... otros tipos de items
        }

    }
}
