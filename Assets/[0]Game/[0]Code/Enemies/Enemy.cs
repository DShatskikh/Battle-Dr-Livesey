using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField]
        protected List<AttackBase> _attackPrefabs;

        public string Name;
        public int MaxHealth;
        public int Health;
        public int Damage;
        public int Protection;
        public int MercyProgress;
        public MessageBoxNoController MessageBox;
        
        public bool IsCanMercy => MercyProgress >= 100 && !IsMercy;
        public bool IsMercy;
        public bool IsContinuesFight => !IsMercy && Health > 0;

        public abstract void TakeDamage(int damage);
        public abstract void Act(Act act);
        public abstract void Mercy(MercyOptionType optionType);
        public abstract string GetInfo();
        public abstract Act[] GetActs();
        public abstract bool TryComment();
        public abstract void Dead();
        public abstract AttackBase GetAttack();

        private void Awake()
        {
            Health = MaxHealth;
        }
    }
}