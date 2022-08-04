using BattleArena.Gameplay.Systems;
using System;
using UnityEngine;

namespace BattleArena.Gameplay.Combat
{
    public class Attacker : MonoBehaviour, IAttacker
    {
        private int m_damage;

        public event Action OnDamagedDamageable;
        public int damage => m_damage;

        void IAttacker.SetDamage(int damage)
        {
            m_damage = damage;
        }

        public void DealDamageTo(Damageable damageable)
        {
            CombatManager.ResolveCombat(this, damageable);
            OnDamagedDamageable?.Invoke();
        }
    }
}