using System;
using UnityEngine;

namespace BattleArena.Gameplay.Combat
{
    public class DamageCollider : MonoBehaviour
    {
        private Attacker m_attacker;
        public event Action OnCollisionWithDamageable;

        private void OnCollision(Collider2D collision)
        {
            if (collision.CompareTag("Hitbox"))
            {
                var damageable = collision.GetComponentInParent<Damageable>();
                m_attacker.DealDamageTo(damageable);
                OnCollisionWithDamageable?.Invoke();
            }
        }

        private void Awake()
        {
            m_attacker = GetComponentInParent<Attacker>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnCollision(collision);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollision(collision.collider);
        }
    }
}