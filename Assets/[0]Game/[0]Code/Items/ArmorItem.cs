using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "ArmorItem", menuName = "Data/Items/ArmorItem", order = 38)]
    public class ArmorItem : Item
    {
        public int Protection;
        
        public override List<Command> Execute()
        {
            var commands = new List<Command>();

            var model = GameData.GetInstance().Character.Model;
            var previousArmor = model.ArmorItem;
            model.ArmorItem = this;
            
            if (previousArmor)
                model.Items.Add(previousArmor);
            
            commands.Add(new BattleMessageCommand($"Вы надели {Name}\nВаша защита {Protection}"));
            return commands;
        }
    }
}