using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CharacterModel
    {
        public float Health { get; set; }
        public float MaxHealth { get; set; }
        public float Speed { get; set; }
        public Vector2 Direction { get; set; }
        public bool IsMove => Speed > 0;
        public WeaponItem WeaponItem;
        public ArmorItem ArmorItem;
        public List<Item> Items = new List<Item>();

        public event Action<float> OnHealthChanged;
        public event Action<float> OnSpeedChanged;

        public void TakeDamage(float amount)
        {
            Health -= amount;
            OnHealthChanged?.Invoke(Health);
        }

        public void UpgradeSpeed(float speed)
        {
            Speed = speed;
            OnSpeedChanged?.Invoke(speed);
        }
    }
}