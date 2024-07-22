using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "BattleSlotConfig", menuName = "Data/BattleSlotConfig", order = 31)]
    public class BattleSlotConfig : ScriptableObject
    {
        public MenuOptionType MenuOptionType;
        public string Label;
        public Sprite Icon;
    }
}