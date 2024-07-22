﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class TypingText
    {
        private TMP_Text _label;
        private Coroutine _coroutine;
        private string _finallyText;
        private InputAction _cancelAction;

        public TypingText(TMP_Text label)
        {
            _label = label;
            _cancelAction = GameData.GetInstance().PlayerInput.actions["Cancel"];
        }

        public void StartTyping(string text)
        {
            _label.gameObject.SetActive(true);
            _finallyText = text;
            _cancelAction.started += CancelActionOnStarted;
            
            if (_coroutine != null)
                GameData.GetInstance().CoroutineRunner.StopCoroutine(_coroutine);
            
            _coroutine = GameData.GetInstance().CoroutineRunner.StartCoroutine(TypingProcess());
        }

        public void StopTyping()
        {
            _cancelAction.started -= CancelActionOnStarted;
            
            if (_coroutine != null)
                GameData.GetInstance().CoroutineRunner.StopCoroutine(_coroutine);
            
            _label.gameObject.SetActive(false);
        }

        public void SkipTyping()
        {
            if (_coroutine != null)
                GameData.GetInstance().CoroutineRunner.StopCoroutine(_coroutine);
            
            _label.text = _finallyText;
        }

        private void CancelActionOnStarted(InputAction.CallbackContext obj) => 
            SkipTyping();

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