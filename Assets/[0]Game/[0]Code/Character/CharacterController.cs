using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class CharacterController : MonoBehaviour
    {
        public CharacterModel Model;
        public CharacterView View;
        
        private Mover _mover;
        private PlayerInput _input;
        private InputAction _moveAction;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            Model = new CharacterModel();
            Model.Health = Model.MaxHealth = 100f;
            Model.Speed = 5f;

            View.SetModel(Model);
            
            _rigidbody2D = GetComponent<Rigidbody2D>();
            
            _mover = new Mover(Model, _rigidbody2D, 3f);

            _input = GameData.GetInstance().PlayerInput;
            _moveAction = _input.actions["Move"];
        }

        private void OnDisable()
        {
            GameData.GetInstance().Character.GetComponent<BoxCollider2D>().enabled = false;
            Model.Speed = 0;
            _rigidbody2D.velocity = Vector2.zero;
        }

        private void Update()
        {
            Model.Direction = _moveAction.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            _mover.Move();
        }
    }
}