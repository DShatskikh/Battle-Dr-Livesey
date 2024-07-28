namespace Game
{
    public class ShopSlotModel
    {
        public bool IsSelected;
        public ShopSlotConfig Config;
        
        public ShopSlotModel(ShopSlotConfig config)
        {
            Config = config;
        }
    }
}