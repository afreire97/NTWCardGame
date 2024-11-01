﻿using NTWCardGame.Domain.Cards.Items;
using NTWCardGame.Models;
using System;

namespace NTWCardGame.Domain.Cards.Player
{
    public class Enemy : Character
    {

 public Enemy()
        {
            
        }
        protected Enemy(CharacterEntity characterEntity)
        {
            Id = characterEntity.Id;
            Name = characterEntity.Name;
            Health = characterEntity.Health;
            Mana = characterEntity.Mana;
            BodyHeat = characterEntity.BodyHeat;
            AttackDmg = characterEntity.AttackDmg;
            Defense = characterEntity.Defense;
            HitChance = characterEntity.HitChance;
            AvatarImage = characterEntity.AvatarImage;
        }
       
        public EnemyType Type { get; set; } // Agrega un tipo de enemigo (ej: guerrero, mago)

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

           
        }

        public override void UseItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
    public enum EnemyType
    {
        Warrior,
        Mage,
        Rogue,
        Boss,
        // Agrega más tipos según sea necesario
    }
}
