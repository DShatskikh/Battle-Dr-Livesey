using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class Battle : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _label;
        
        public Transform CharacterPoint;
        public Transform[] EnemyPoints;
        public TypingText TextMessage;
        public MessageBox MenuMessageBox;
        public GameObject Canvas;
        public HeartType HeartType = HeartType.Red;
        public Enemy[] Enemies;
        public Enemy SelectedEnemy;

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

        public void Turn(List<Command> commands = null)
        {
            commands ??= new List<Command>();
            
            commands.Add(new BattleEnemyMessageCommand("Ахахаха"));
            commands.Add(new EnemyTurnCommand());
            commands.Add(new StartCharacterTurn());
            GameData.GetInstance().CommandManager.StartCommands(commands);
        }
    }
}