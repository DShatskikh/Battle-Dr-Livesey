using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    [CreateAssetMenu(fileName = "ShopSlotConfig", menuName = "Data/ShopSlotConfig", order = 36)]
    public class ShopSlotConfig : ScriptableObject
    {
        public ShopMenuOptionType ShopMenuOptionType;
        public string Name;
    }
}