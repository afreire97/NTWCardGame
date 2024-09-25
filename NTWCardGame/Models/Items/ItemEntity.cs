using System.ComponentModel.DataAnnotations;
using static NTWCardGame.Domain.Cards.Items.Item;

namespace NTWCardGame.Models.Items
{
    public class ItemEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        //public Rarity Rarity  { get; set; }
        public int Value { get; set; }
        public
        bool Stackable { get; set; }
    }
}
