using Mono.TextTemplating;
using NTWCardGame.Domain.Cards.Items;
using NTWCardGame.Domain.Skill ;
using NTWCardGame.Models;
using System;

namespace NTWCardGame.Domain.Cards.Player
{
    public class Player : Character
    {



        protected Player(CharacterEntity characterEntity)
        {
            Id = characterEntity.Id;
            Name = characterEntity.Name;
            Health = characterEntity.Health;
            Mana = characterEntity.Mana;
            BodyHeat = characterEntity.BodyHeat;
            AttackDmg = characterEntity.AttackDmg;
            Defense = characterEntity.Defense;
            HitChance = characterEntity.HitChance;
        }
        public List<Items.Item> Inventory { get; set; }
        public Dictionary<Items.EquipmentSlot, Items.Equipment> Equipment { get; set; }
        public Dictionary<Stat, int> Stats { get; set; }
        public List<Skill.Skill> Skills { get; set; }

        public override void TakeDamage(int damage)
        {
            // Lógica específica para cuando el jugador recibe daño
            // Por ejemplo, podría activar una habilidad de esquivar
        }

        public override void UseItem(Items.Item item)
        {
            // Lógica específica para cuando el jugador usa un objeto
            // Por ejemplo, añadir un objeto al inventario o consumir una poción
        }

      

        public override void LearnSkill(Skill.Skill skill)
        {
            throw new NotImplementedException();
        }

        internal void EquipItem(Equipment equipment)
        {
            throw new NotImplementedException();
        }
    }
}
