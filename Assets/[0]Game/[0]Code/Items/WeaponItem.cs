using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "WeaponItem", menuName = "Data/Items/WeaponItem", order = 37)]
    public class WeaponItem : Item
    {
        public int Damage;
        
        public override List<Command> Execute()
        {
            var commands = new List<Command>();
                
            commands.Add(new BattleMessageCommand($"Вы экипировали {Name}\nВаш урон равен {Damage}"));
            return commands;
        }
    }
}