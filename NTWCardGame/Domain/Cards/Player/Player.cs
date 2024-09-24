using NTWCardGame.Domain.Skill ;
using System;

namespace NTWCardGame.Domain.Cards.Player
{
    public class Player : Character
    {
        public List<Item> Inventory { get; set; }
        public List<Skill.Skill> Skills { get; set; }

        public override void TakeDamage(int damage)
        {
            // Lógica específica para cuando el jugador recibe daño
            // Por ejemplo, podría activar una habilidad de esquivar
        }

        public override void UseItem(Item item)
        {
            // Lógica específica para cuando el jugador usa un objeto
            // Por ejemplo, añadir un objeto al inventario o consumir una poción
        }

      

        public override void LearnSkill(Skill.Skill skill)
        {
            throw new NotImplementedException();
        }
    }
}
