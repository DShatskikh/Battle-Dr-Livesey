namespace Game
{
    public class FightSlotModel
    {
        public readonly Enemy Enemy;
        public bool IsSelected;

        public FightSlotModel(Enemy enemy)
        {
            Enemy = enemy;
        }
    }
}