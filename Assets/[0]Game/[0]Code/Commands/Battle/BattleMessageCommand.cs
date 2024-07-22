using UnityEngine.Events;

namespace Game
{
    public class BattleMessageCommand : Command
    {
        private string _text;
        
        public BattleMessageCommand(string text)
        {
            _text = text;
        }
        
        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().Battle.MenuMessageBox.StartTyping(_text, onCompleted);
        }
    }
}