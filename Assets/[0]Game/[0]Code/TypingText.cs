using System.Collections;
using TMPro;
using UnityEngine;

namespace Game
{
    public class TypingText
    {
        private TMP_Text _label;
        private Coroutine _coroutine;

        public TypingText(TMP_Text label)
        {
            _label = label;
        }

        public void StartTyping(string text)
        {
            _label.gameObject.SetActive(true);
            
            if (_coroutine != null)
                GameData.GetInstance().CoroutineRunner.StopCoroutine(_coroutine);
            
            _coroutine = GameData.GetInstance().CoroutineRunner.StartCoroutine(TypingProcess(text));
        }

        public void StopTyping()
        {
            if (_coroutine != null)
                GameData.GetInstance().CoroutineRunner.StopCoroutine(_coroutine);
            
            _label.gameObject.SetActive(false);
        }

        private IEnumerator TypingProcess(string finallyText)
        {
            _label.text = "";

            var currentText = "";
            int _countSymbol = 0;
            
            var length = finallyText.Length;
            
            while (_countSymbol != length)
            {
                currentText += finallyText[_countSymbol];
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