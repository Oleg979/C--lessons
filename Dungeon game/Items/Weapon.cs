namespace Game.Items
{
    class Weapon : Item
    {
        public int Dmg { get; }
        public Weapon(string n, int p, int dmg) : base(n, p) => Dmg = dmg;
        public override string ToString() => $"{Name}(+{Dmg} dmg)";
    }
}
