namespace Game
{
    public class BuyShopSlotModel
    {
        public bool IsSelected;
        public BuyShopConfig Config;

        public BuyShopSlotModel(BuyShopConfig config)
        {
            Config = config;
        }
    }
}