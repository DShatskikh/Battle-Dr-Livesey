using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "GameOverButtonConfig", menuName = "Data/GameOverButtonConfig", order = 33)]
    public class GameOverSlotConfig : ScriptableObject
    {
        public string Name;
        public GameOverOptionType OptionType;
    }
}