using System;
using TMPro;
using UnityEngine;

namespace Game
{
    public class Battle : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _label;
        
        public Transform CharacterPoint;
        public Transform EnemyPoint;
        public TypingText TextMessage;
        public GameObject Canvas;
        public HeartType HeartType = HeartType.Red;
        public Enemy Enemy;

        private void Awake()
        {
            TextMessage = new TypingText(_label);
        }
        
        public Sprite GetHeartSprite()
        {
            foreach (var pair in GameData.GetInstance().AssetProvider.PairHeartSprites)
            {
                if (pair.HeartType == HeartType)
                    return pair.Sprite;
            }

            throw new Exception("Нет обьекта в списке");
        }
    }
}