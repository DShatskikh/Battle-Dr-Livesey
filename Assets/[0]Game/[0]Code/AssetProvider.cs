using Unity.Cinemachine;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "AssetProvider", menuName = "Data/AssetProvider", order = 30)]
    public class AssetProvider : ScriptableObject
    {
        public BattleSlotConfig[] BattleButtonConfigs;
        public MercySlotConfig[] MercySlotConfigs;
        public PairHeartSprite[] PairHeartSprites;
        public CinemachineBlenderSettings NotBlender;
        
        [Header("Prefabs")]
        public BattleSlotController BattleSlotPrefab;
        public FightSlotController FightSlotPrefab;
        public ActSlotController ActSlotPrefab;
        public ItemSlotController ItemSlotPrefab;
        public MercySlotController MercySlotPrefab;
    }
}