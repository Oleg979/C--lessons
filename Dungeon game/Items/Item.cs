namespace Game.Items
{
    class Item
    {
        public string Name { get; }
        public int Price { get; }
        public Item(string n, int p )
        {
            Name = n;
            Price = p;
        }
        public override string ToString() => Name;
    }
}
