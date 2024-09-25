using NTWCardGame.Domain.Cards.Player;

namespace NTWCardGame.Domain.Effects
{
    public abstract class Effect
    {
        public abstract void Apply(Player player);
    }
}
