namespace Game.Items
{
    class Armor : Item
    {
        public int Defense { get; }
        public Armor(string n, int p, int d) : base(n, p) => Defense = d;
        public override string ToString() => $"{Name}(+{Defense} hp)";
    }
}
