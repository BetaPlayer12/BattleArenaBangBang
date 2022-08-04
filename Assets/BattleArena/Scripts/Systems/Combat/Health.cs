using System;
using UnityEngine;

namespace BattleArena.Gameplay.Combat
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField]
        private int m_maxValue;
        private int m_currentValue;

        public int currentValue => m_currentValue;
        public int maxValue => m_maxValue;
        public event Action<int> OnValueChanged;

        void IHealth.SetCurrent(int value)
        {
            SetCurrent(value);
        }

        void IHealth.SetMax(int maxValue)
        {
            m_maxValue = maxValue;
        }
        void IHealth.Reset()
        {
            SetCurrent(m_maxValue);
        }

        public void Add(int value)
        {
            SetCurrent(m_currentValue + value);
        }

        private void SetCurrent(int value)
        {
            m_currentValue = Mathf.Clamp(value, 0, m_maxValue);
            OnValueChanged?.Invoke(m_currentValue);
        }
    }
}