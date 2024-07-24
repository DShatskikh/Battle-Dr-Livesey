using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{
    public abstract class Enemy : MonoBehaviour
    {
        public int MaxHealth;
        public int Health;
        public int Damage;
        public int Protection;
        public string Name;
        public MessageBoxNoController MessageBox;

        public abstract void TakeDamage(int damage);
        public abstract void Act(Act act);
        public abstract void Mercy(MercyOptionType optionType);
        public abstract string GetInfo();
        public abstract Act[] GetActs();

        private void Awake()
        {
            Health = MaxHealth;
        }
    }
}