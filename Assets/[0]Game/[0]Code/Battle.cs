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
        public List<Enemy> AliveEnemies;
        public Enemy SelectedEnemy;
        public List<MoveBattleData> MoveBattleData { get; set; }
        public bool IsAllyDiedTurn { get; set; }

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
            
            if (IsEndBattle())
            {
                commands.Add(new BattleMessageCommand("Вы победили\nВы получили 0 Оп 0 Монет"));
                commands.Add(new OutroBattleCommand());
            }
            else
            {
                commands.Add(new BattleAllEnemyMessageCommand());
                commands.Add(new EnemyTurnCommand());
                commands.Add(new StartCharacterTurn());
            }

            GameData.GetInstance().CommandManager.StartCommands(commands);
            IsAllyDiedTurn = false;
        }

        public void Run(List<Command> commands)
        {
            commands.Add(new BattleMessageCommand("Вы сбежали\nВы получили 0 ОП"));
            commands.Add(new OutroBattleCommand());
            GameData.GetInstance().CommandManager.StartCommands(commands);
        }

        private bool IsEndBattle()
        {
            bool isEndBattle = true;
            
            foreach (var enemy in Enemies)
            {
                if (enemy.IsContinuesFight)
                    isEndBattle = false;
            }

            return isEndBattle;
        }
    }
}