using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Game
{
    public class MessageBox : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _label;
        
        private Coroutine _coroutine;
        private string _finallyText;
        private InputAction _cancelAction;
        private InputAction _submitAction;

        public UnityAction OnClose;

        public void Awake()
        {
            _cancelAction = GameData.GetInstance().PlayerInput.actions["Cancel"];
            _submitAction = GameData.GetInstance().PlayerInput.actions["Submit"];
        }

        public void StartTyping(string text, UnityAction onClose)
        {
            gameObject.SetActive(true);
            OnClose = onClose;
            _label.gameObject.SetActive(true);
            _finallyText = text;

            _cancelAction.started += CancelActionOnStarted;
            _submitAction.started += SubmitActionOnStarted;
            
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            
            _coroutine = StartCoroutine(TypingProcess());
        }

        public void StopTyping()
        {
            _cancelAction.started -= CancelActionOnStarted;
            _cancelAction.started -= SubmitActionOnStarted;
            
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            
            _label.gameObject.SetActive(false);
            gameObject.SetActive(false);
            OnClose.Invoke();
        }

        public void SkipTyping()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            
            _label.text = _finallyText;
        }
        
        private void CancelActionOnStarted(InputAction.CallbackContext obj) => 
            SkipTyping();

        private void SubmitActionOnStarted(InputAction.CallbackContext obj)
        {
            if (_label.text == _finallyText)
                StopTyping();
        }

        private IEnumerator TypingProcess()
        {
            _label.text = "";

            var currentText = "";
            int _countSymbol = 0;
            
            var length = _finallyText.Length;
            
            while (_countSymbol != length)
            {
                currentText += _finallyText[_countSymbol];
                _label.text = currentText;

                for (int i = currentText.Length; i < length; i++)
                {
                    _label.text += ' ';
                }
                
                yield return new WaitForSeconds(0.05f);
                _countSymbol++;
            }
        }
    }
}