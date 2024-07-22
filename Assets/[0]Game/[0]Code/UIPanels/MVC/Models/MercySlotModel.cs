namespace Game
{
    public class MercySlotModel
    {
        public MercySlotConfig Config { get; set; }
        public bool IsMercy;
        public bool IsSelected;
        
        public MercySlotModel(MercySlotConfig config)
        {
            Config = config;
        }
    }
}