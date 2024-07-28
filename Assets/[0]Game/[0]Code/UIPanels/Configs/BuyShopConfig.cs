using System;

namespace Game
{
    [Serializable]
    public struct BuyShopConfig
    {
        public Item Item;
        public bool IsSold;
    }
}