namespace Game.Characters
{
    class NormalTactic : Tactic
    {
        public NormalTactic(Character c) : base(c) { }
        public NormalTactic() : base() { }

        public override bool NextAction(Character enemy)
        {
            if (Character.MP >= 2)
            {
                Attack(enemy);
                return false;
            }
            else if(Character.MP >= 1 && !Character.Blocked)
            {
                Block();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
