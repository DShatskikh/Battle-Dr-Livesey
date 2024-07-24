using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Game
{
    public class MessageBoxNoController : MonoBehaviour
    {
        [SerializeField]
        protected TMP_Text _label;
        
        private Coroutine _coroutine;
        protected string _finallyText;

        public UnityAction OnClose;

        public virtual void StartTyping(string text)
        {
            gameObject.SetActive(true);
            _label.gameObject.SetActive(true);
            _finallyText = text;

            if (_coroutine != null)
                StopCoroutine(_coroutine);
            
            _coroutine = StartCoroutine(TypingProcess());
        }

        public virtual void StopTyping()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            
            _label.gameObject.SetActive(false);
            gameObject.SetActive(false);
            OnClose?.Invoke();
        }

        public void SkipTyping()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            
            _label.text = _finallyText;
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