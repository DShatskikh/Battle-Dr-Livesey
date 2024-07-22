using UnityEngine.Events;

namespace Game
{
    public class BattleEnemyMessageCommand : Command
    {
        private string _text;
        
        public BattleEnemyMessageCommand(string text)
        {
            _text = text;
        }
        
        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().Battle.Enemy.MessageBox.StartTyping(_text, onCompleted);
        }
    }
}