namespace NTWCardGame.Models
{
    public class CharacterEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int BodyHeat { get; set; }
        public int AttackDmg { get; set; }
        public int Defense { get; set; }
        public double HitChance { get; set; }
        public string AvatarImage { get; set; }
    }
}
