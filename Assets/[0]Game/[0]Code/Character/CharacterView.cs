using System;
using UnityEngine;

namespace Game
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private CharacterController _controller;

        private CharacterModel _model;
        
        private void Awake()
        {
            _model = _controller.Model;
            
            _model.OnSpeedChanged += UpgradeSpeed;
        }

        private void UpgradeSpeed(float speed)
        {
            
        }
    }
}