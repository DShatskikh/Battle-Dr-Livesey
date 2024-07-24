using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "HealItem", menuName = "Data/Items/HealItem", order = 36)]
    public class HealItem : Item
    {
        public int Health;
        
        public override List<Command> Execute()
        {
            var commands = new List<Command>();
                
            commands.Add(new BattleMessageCommand($"Вы использовали {Name}\nВаше здоровте увеличилось на {Health}"));
            return commands;
        }
    }
}