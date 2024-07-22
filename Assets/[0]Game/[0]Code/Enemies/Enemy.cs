using System;
using System.Collections.Generic;
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
        public MessageBox MessageBox;
        public abstract void Turn(List<Command> commands = null);
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