using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class InfoAct : Act
    {
        public InfoAct()
        {
            Name = "Проверить";
        }

        public override void Execute(Enemy enemy)
        {
            var commands = new List<Command>();
                
            commands.Add(new BattleMessageCommand($"{enemy.GetInfo()}"));
            enemy.Turn(commands);
        }
    }
}