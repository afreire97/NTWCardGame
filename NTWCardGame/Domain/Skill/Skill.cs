using NTWCardGame.Domain.Cards.Player;

namespace NTWCardGame.Domain.Skill
{
    public abstract class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManaCost { get; set; }

        public abstract void Cast(Character caster, Character target);
    }
}
