using System;
using UnityEngine;

namespace BattleArena.Gameplay.Combat
{
    public class RoarDamageCollider : MonoBehaviour
    {
        private Attacker m_attacker;
        public event Action OnCollisionWithDamageable;

        private void Awake()
        {
            m_attacker = GetComponentInParent<Attacker>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject != null)
            {
                var projectile = collision.GetComponent<Projectile>();

                if (projectile != null)
                {
                    Destroy(projectile.gameObject);
                }
            }
            if (collision.CompareTag("Hitbox"))
            {
                var damageable = collision.GetComponentInParent<Damageable>();
                m_attacker.DealDamageTo(damageable);
                OnCollisionWithDamageable?.Invoke();
            }
        }
    }
}