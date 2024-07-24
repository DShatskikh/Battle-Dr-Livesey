using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Game
{
    public class BattleEnemyMessageCommand : Command
    {
        private readonly string _text;
        private UnityAction _onCompleted;
        
        public BattleEnemyMessageCommand(string text)
        {
            _text = text;
        }
        
        public override void Execute(UnityAction onCompleted)
        {
            _onCompleted = onCompleted;
            GameData.GetInstance().PlayerInput.actions["Submit"].performed += Onperformed;

            foreach (var enemy in GameData.GetInstance().Battle.Enemies) 
                enemy.MessageBox.StartTyping(_text);
        }

        private void Onperformed(InputAction.CallbackContext obj)
        {
            GameData.GetInstance().PlayerInput.actions["Submit"].performed -= Onperformed;
            
            foreach (var enemy in GameData.GetInstance().Battle.Enemies) 
                enemy.MessageBox.StopTyping();

            _onCompleted.Invoke();
        }
    }
}