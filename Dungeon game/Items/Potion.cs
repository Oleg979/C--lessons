using Game.Effects;
using System.Collections.Generic;

namespace Game.Items
{
    class Potion : Item
    {
        public List<Effect> Effects { get; }
        public Potion(string n, int p, Effect e) : base(n, p)
        {
            Effects = new List<Effect>
            {
                e
            };
        }
        public Potion AddEffect(Effect e)
        {
            Effects.Add(e);
            return this;
        }
        public override string ToString()
        {
            string S = $"{Name}: ";
            Effects.ForEach(e => {
                S += e.ToString() + " "; 
            });
            return S;
        }
    }
}
