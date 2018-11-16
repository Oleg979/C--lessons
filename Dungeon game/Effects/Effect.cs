namespace Game.Effects
{
    class Effect
    {
        public int Amount { get; }
        public Stat Stat { get; }

        public Effect(int a, Stat s)
        {
            Amount = a;
            Stat = s;
        }
        public override string ToString() => (Amount > 0 ? "Restore " : "Reduce ") + Amount + (Stat == Stat.HP ? " HP" : " MP");
    }
}
