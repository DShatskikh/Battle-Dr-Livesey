namespace Game
{
    public class SellShopSlotModel
    {
        public bool IsSelected;
        public Item Item;
        
        public SellShopSlotModel(Item item)
        {
            Item = item;
        }
    }
}