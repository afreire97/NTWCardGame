namespace NTWCardGame.Domain.Cards.Player
{
    public class Stat
    {
        public string Name { get; set; }
        public int BaseValue { get; set; }
        public int Modifier { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public int TotalValue
        {
            get
            {
                return Math.Clamp(BaseValue + Modifier, MinValue, MaxValue);
            }
        }
    }
}
