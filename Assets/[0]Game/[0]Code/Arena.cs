using System;
using UnityEngine;

namespace Game
{
    public class Arena : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public Vector2 GetSizeMoveField()
        {
            return _spriteRenderer.size;
        }
    }
}