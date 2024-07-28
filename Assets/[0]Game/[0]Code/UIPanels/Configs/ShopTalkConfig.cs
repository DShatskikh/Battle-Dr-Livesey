using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    [CreateAssetMenu(fileName = "ShopTalkConfig", menuName = "Data/ShopTalkConfig", order = 37)]
    public class ShopTalkConfig : ScriptableObject
    {
        public string Name;
        public string Message;
    }
}