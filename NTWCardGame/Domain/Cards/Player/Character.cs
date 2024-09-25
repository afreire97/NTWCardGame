using NTWCardGame.Domain.Skill;
using NTWCardGame.Models;
namespace NTWCardGame.Domain.Cards.Player
  
{

    public abstract class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int BodyHeat { get; set; } // Para la simpatía


        public int AttackDmg { get; set; }
        public int Defense { get; set; }
        public double HitChance { get; set; }
        public string AvatarImage { get; set; }





        public virtual void Attack(Character target, Skill.Skill skill = null)
        {
            if (skill != null)
            {
                skill.Cast(this, target);
            }
            else
            {
                // Lógica básica de ataque
                var damage = CalculateDamage();
                target.TakeDamage(damage);
            }
        }

        protected virtual int CalculateDamage()
        {
            // Cálculo básico del daño
            return this.AttackDmg; // This is the correct way to return the Attack value
        }


        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            //Console.WriteLine("El personaje ha recibido " + damage + " de daño.");
        }
        public abstract void UseItem(Items.Item item);
        public virtual void LearnSkill(Skill.Skill skill)
        {
            // Comportamiento por defecto: Ignorar la habilidad
            Console.WriteLine("Este personaje no puede aprender habilidades.");
        }

    }
}
