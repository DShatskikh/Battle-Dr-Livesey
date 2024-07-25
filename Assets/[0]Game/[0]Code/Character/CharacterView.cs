using System;
using UnityEngine;

namespace Game
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        
        private CharacterModel _model;
        
        private void Awake()
        {
            _model.SpeedChanged += OnSpeedChanged;
        }

        public void SetModel(CharacterModel model)
        {
            _model = model;
        }
        
        private void OnSpeedChanged(float speed)
        {
            
        }
    }
}