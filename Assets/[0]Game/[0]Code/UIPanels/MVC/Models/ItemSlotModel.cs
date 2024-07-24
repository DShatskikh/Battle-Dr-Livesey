namespace Game
{
    public class ItemSlotModel
    {
        public bool IsSelected;
        public Item Item;
        
        public ItemSlotModel(Item item)
        {
            Item = item;
        }
    }
}