namespace Game
{
    public class SelectTalkShopSlotModel
    {
        public bool IsSelected;
        public ShopTalkConfig Config;
        
        public SelectTalkShopSlotModel(ShopTalkConfig config)
        {
            Config = config;
        }
    }
}