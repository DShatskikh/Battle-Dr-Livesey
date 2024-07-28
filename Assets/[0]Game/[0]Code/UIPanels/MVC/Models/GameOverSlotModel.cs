namespace Game
{
    public class GameOverSlotModel
    {
        public GameOverSlotConfig Config { get; set; }
        public bool IsSelected;
        
        public GameOverSlotModel(GameOverSlotConfig config)
        {
            Config = config;
        }
    }
}