using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class HeartController : MonoBehaviour
    {
        private const float Speed = 3f;
        
        public HeartModel Model;
        public HeartView View;

        private PlayerInput _input;
        private InputAction _moveAction;
        private Rigidbody2D _rigidbody;
        private Arena _arena;
        private Shield _shield;

        public void SetModel(HeartModel model)
        {
            Model = model;
            View.SetModel(Model);

            _shield = new Shield(Model);
            
            _rigidbody = GetComponent<Rigidbody2D>();
            _input = GameData.GetInstance().PlayerInput;
            _moveAction = _input.actions["Move"];
            _arena = GameData.GetInstance().Battle.Arena;
        }
        
        private void Update()
        {
            Model.Direction = _moveAction.ReadValue<Vector2>();
            LimitMove();
            _shield.Execute(transform.position);
        }

        private void FixedUpdate()
        {
            _rigidbody.linearVelocity = Model.Direction * Speed;
        }

        private void LimitMove()
        {
            var arenaPosition = _arena.transform.position;
            var limitX = _arena.GetSizeMoveField().x / 2 - 0.225f;
            var limitY = _arena.GetSizeMoveField().y / 2 - 0.225f;
            
            transform.position = new Vector2(
                Mathf.Clamp(transform.position.x, -limitX + arenaPosition.x, limitX + arenaPosition.x), 
                Mathf.Clamp(transform.position.y, -limitY + arenaPosition.y, limitY + arenaPosition.y));
        }
    }
}