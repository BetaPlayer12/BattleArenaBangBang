using System;
using UnityEngine;

namespace BattleArena.Gameplay.Combat
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField]
        private Health m_health;

        public event Action IsDead;

        public Health health => m_health;

        public void TakeDamage(int value)
        {
            m_health.Add(-value);
            if(m_health.currentValue == 0)
            {
                IsDead?.Invoke();
            }
        }

        public void Heal(int value)
        {
            m_health.Add(value);
        }
    }
}