using UnityEngine;

namespace Game
{
    public class Mover
    {
        private readonly CharacterModel _model;
        private readonly Rigidbody2D _rigidbody;

        private Vector2 _previousPosition;
        private readonly float _normalSpeed;

        public Mover(CharacterModel model, Rigidbody2D rigidbody, float normalSpeed)
        {
            _model = model;
            _rigidbody = rigidbody;
            _normalSpeed = normalSpeed;
        }

        public void Move()
        {
            _model.UpgradeSpeed((_previousPosition - (Vector2)_rigidbody.transform.position).magnitude);
            _rigidbody.velocity = _model.Direction * _normalSpeed;
        }
        
        public void TryStopMove()
        {
            if (!_model.IsMove)
                return;
            
            _rigidbody.velocity = Vector2.zero;
            _model.UpgradeSpeed(0);
        }
    }
}