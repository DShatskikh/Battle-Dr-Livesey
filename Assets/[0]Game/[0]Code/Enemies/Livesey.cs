﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Livesey : Enemy
    {
        public override void TakeDamage(int damage)
        {
            Health =- damage;
            print("Ливси получил " + damage + " урона");

            if (Health <= 0) 
                Dead();
        }

        public override void Act(Act act)
        {
            act.Execute(this);
        }

        public override void Mercy(MercyOptionType optionType)
        {
            var commands = new List<Command>();
            
            switch (optionType)
            {
                case MercyOptionType.Mercy:
                    Debug.Log("Ливси пощада");
                    commands.Add(new BattleMessageCommand("Вы щадите ливси"));
                    
                    if (MercyProgress >= 100)
                        IsMercy = true;
                    
                    GameData.GetInstance().Battle.Turn(commands);
                    MercyProgress += 100;
                    break;
                case MercyOptionType.Run:
                    Debug.Log("Ливси Побег");
                    GameData.GetInstance().Battle.Run(commands);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(optionType), optionType, null);
            }
        }

        public override string GetInfo()
        {
            return $"{Name} Атака:{Damage} Защита: {Protection}\nВедет здоровый образ жизни";
        }

        public override Act[] GetActs()
        {
            return new Act[]
            {
                new InfoAct(),
                new JokeAct(),
                new JokeAct(),
                new JokeAct()
            };
        }

        public override bool TryComment()
        {
            if (GameData.GetInstance().Battle.IsAllyDiedTurn)
                MessageBox.StartTyping(": (");
            else
                MessageBox.StartTyping("Ахахаха");
            return true;
        }

        public override void Dead()
        {
            GameData.GetInstance().Battle.IsAllyDiedTurn = true;
            GameData.GetInstance().Battle.AliveEnemies.Remove(this);
            gameObject.SetActive(false);
        }

        public class JokeAct : Act
        {
            public JokeAct()
            {
                Name = "Шутка";
            }
            
            public override void Execute(Enemy enemy)
            {
                var commands = new List<Command>();
                
                commands.Add(new BattleMessageCommand("Вы рассказали шутку"));
                GameData.GetInstance().Battle.Turn(commands);
            }
        }
    }
}