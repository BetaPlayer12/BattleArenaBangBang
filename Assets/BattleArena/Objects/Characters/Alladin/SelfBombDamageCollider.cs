using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Combat;
using System;
using UnityEngine;

namespace BattleArena.Tests
{
    public class SelfBombDamageCollider : MonoBehaviour
    {
        private Attacker m_attacker;
        public event Action OnCollisionWithDamageable;

        private Character owner;
        private Damageable m_temp;

        public void SetOwner(Character owner)
        {
            m_temp = owner.GetComponent<Damageable>();
        }

        private void Awake()
        {
            m_attacker = GetComponentInParent<Attacker>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Hitbox"))
            {
                var damageable = collision.GetComponentInParent<Damageable>();
                if (damageable != m_temp)
                {
                    m_attacker.DealDamageTo(damageable);
                    OnCollisionWithDamageable?.Invoke();
                }

            }
        }
    }
}

