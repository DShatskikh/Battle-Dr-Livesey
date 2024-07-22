namespace Game
{
    public abstract class Act
    {
        public Act()
        {
            
        }
        
        public string Name;
        public abstract void Execute(Enemy enemy);
    }
}