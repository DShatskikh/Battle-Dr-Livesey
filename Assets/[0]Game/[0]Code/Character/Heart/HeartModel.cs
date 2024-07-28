using System;
using UnityEngine;

namespace Game
{
    public class HeartModel
    {
        public HeartType HeartType { get; set; }
        public Vector2 Direction { get; set; }
        public bool IsShield { get; set; }
        public float Progress { get; set; }

        public event Action HeartTypeChanged;
        public event Action<bool> IsShieldChanged;

        public void SetHeartType(HeartType heartType)
        {
            HeartType = heartType;
            HeartTypeChanged?.Invoke();
        }

        public void AddTurnProgress(int value)
        {
            Progress += value;
        }

        public void SetIsShield(bool value)
        {
            IsShieldChanged?.Invoke(value);
        }
    }
}