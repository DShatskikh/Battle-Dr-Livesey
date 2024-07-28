using UnityEngine.Events;

namespace Game
{
    public class ShopMessageCommand : Command
    {
        private string _text;
        
        public ShopMessageCommand(string text)
        {
            _text = text;
        }
        
        public override void Execute(UnityAction onCompleted)
        {
            GameData.GetInstance().Shop.MessageBox.StartTyping(_text, onCompleted);
        }
    }
}