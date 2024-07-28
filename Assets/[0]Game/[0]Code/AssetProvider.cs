using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace Game
{
    [CreateAssetMenu(fileName = "AssetProvider", menuName = "Data/AssetProvider", order = 30)]
    public class AssetProvider : ScriptableObject
    {
        public BattleSlotConfig[] BattleButtonConfigs;
        public MercySlotConfig[] MercySlotConfigs;
        public GameOverSlotConfig[] GameOverButtonConfigs;
        public ShopSlotConfig[] ShopSlotConfigs;
        public PairHeartSprite[] PairHeartSprites;
        public CinemachineBlenderSettings NotBlender;
        
        [Header("Prefabs")]
        public BattleSlotController BattleSlotPrefab;
        public FightSlotController FightSlotPrefab;
        public ActSlotController ActSlotPrefab;
        public ItemSlotController ItemSlotPrefab;
        public MercySlotController MercySlotPrefab;
        public GameOverSlotController GameOverSlotPrefab;
        public ShopSlotController ShopSlotPrefab;
        public BuyShopSlotController BuyShopSlotPrefab;
        public SellShopSlotController SellShopSlotPrefab;
        public SelectTalkShopSlotController SelectTalkShopSlotPrefab;

        public Sprite GetHeartSprite(HeartType heartType)
        {
            foreach (var pair in GameData.GetInstance().AssetProvider.PairHeartSprites)
            {
                if (pair.HeartType == heartType)
                    return pair.Sprite;
            }

            throw new Exception("Нет обьекта в списке");
        }
    }
}