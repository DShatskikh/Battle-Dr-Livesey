using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "MercySlotConfig", menuName = "Data/MercySlotConfig", order = 32)]
    public class MercySlotConfig : ScriptableObject
    {
        public string Name;
        public MercyOptionType OptionType;
    }
}