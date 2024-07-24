using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Game
{
    public class MessageBox : MessageBoxNoController
    {
        private InputAction _cancelAction;
        private InputAction _submitAction;

        public void Awake()
        {
            _cancelAction = GameData.GetInstance().PlayerInput.actions["Cancel"];
            _submitAction = GameData.GetInstance().PlayerInput.actions["Submit"];
        }

        public void StartTyping(string text, UnityAction onClose)
        {
            OnClose = onClose;
            StartTyping(text);
        }
        
        public override void StartTyping(string text)
        {
            base.StartTyping(text);

            _cancelAction.started += CancelActionOnStarted;
            _submitAction.started += SubmitActionOnStarted;
        }

        public override void StopTyping()
        {
            _cancelAction.started -= CancelActionOnStarted;
            _cancelAction.started -= SubmitActionOnStarted;
            
            base.StopTyping();
        }

        private void CancelActionOnStarted(InputAction.CallbackContext obj) => 
            SkipTyping();

        private void SubmitActionOnStarted(InputAction.CallbackContext obj)
        {
            if (_label.text == _finallyText)
                StopTyping();
        }
    }
}