using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Item", menuName = "Data/Items/Item", order = 35)]
    public class Item : ScriptableObject
    {
        public string Name = "Добавь название";
        public string Description = "Добавь описание";

        public virtual List<Command> Execute()
        {
            var commands = new List<Command>();
                
            commands.Add(new BattleMessageCommand($"Вы использовали {Name}\nНичего не произошло"));
            return commands;
        }
    }
}