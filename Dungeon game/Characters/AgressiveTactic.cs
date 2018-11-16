namespace Game.Characters
{
    class AgressiveTactic : Tactic
    {
        public AgressiveTactic(Character c) : base(c) {}
        public AgressiveTactic() : base() {}

        public override bool NextAction(Character enemy)
        {
            if(Character.MP >= 3)
            {
                UltimateAttack(enemy);
                return false;
            }
            else if(Character.MP >= 2)
            {
                Attack(enemy);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
