using NTWCardGame.Domain.Skill;
namespace NTWCardGame.Domain.Cards.Player
  
{

    public abstract class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int BodyHeat { get; set; } // Para la simpatía


        public int AttackDamage { get; set; }
        public int Defense { get; set; }
        public double HitChance { get; set; }

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
            return Attack;
        }

        public abstract void TakeDamage(int damage);
        public abstract void UseItem(Item item);
        public virtual void LearnSkill(Skill.Skill skill)
        {
            // Comportamiento por defecto: Ignorar la habilidad
            Console.WriteLine("Este personaje no puede aprender habilidades.");
        }



    }
}
