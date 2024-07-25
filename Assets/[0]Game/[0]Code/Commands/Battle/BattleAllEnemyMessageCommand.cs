using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Game
{
    public class BattleAllEnemyMessageCommand : Command
    {
        private UnityAction _onCompleted;
        
        public BattleAllEnemyMessageCommand()
        {
            
        }
        
        public override void Execute(UnityAction onCompleted)
        {
            _onCompleted = onCompleted;
            GameData.GetInstance().PlayerInput.actions["Submit"].performed += Onperformed;

            foreach (var enemy in GameData.GetInstance().Battle.AliveEnemies) 
                enemy.TryComment();
        }

        private void Onperformed(InputAction.CallbackContext obj)
        {
            GameData.GetInstance().PlayerInput.actions["Submit"].performed -= Onperformed;
            
            foreach (var enemy in GameData.GetInstance().Battle.AliveEnemies) 
                enemy.MessageBox.StopTyping();

            _onCompleted.Invoke();
        }
    }
}