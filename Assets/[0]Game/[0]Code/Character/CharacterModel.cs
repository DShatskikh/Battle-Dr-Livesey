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
        public int Money { get; set; }

        public WeaponItem WeaponItem;
        public ArmorItem ArmorItem;
        public List<Item> Items = new List<Item>();

        public event Action<float> HealthChanged;
        public event Action<float> SpeedChanged;

        public void TakeDamage(float amount)
        {
            Health -= amount;
            HealthChanged?.Invoke(Health);
        }

        public void UpgradeSpeed(float speed)
        {
            Speed = speed;
            SpeedChanged?.Invoke(speed);
        }
    }
}