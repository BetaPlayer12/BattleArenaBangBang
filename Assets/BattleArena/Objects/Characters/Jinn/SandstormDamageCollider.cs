using Spine.Unity;
using System;
using UnityEngine;

namespace BattleArena.Gameplay.Combat
{
    public class SandstormDamageCollider : MonoBehaviour
    {
        [SerializeField]
        private float m_delayBeforeAttack;

        private Collider2D m_collider;
        private float m_currentTimer;
        private SkeletonAnimation animator;
        private Attacker m_attacker;
        public event Action OnCollisionWithDamageable;

        private void Awake()
        {
            m_attacker = GetComponentInParent<Attacker>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Hitbox"))
            {
                var damageable = collision.GetComponentInParent<Damageable>();
                m_attacker.DealDamageTo(damageable);
                OnCollisionWithDamageable?.Invoke();
            }
        }

        //private void OnTriggerStay2D(Collider2D collision)
        //{
        //    if (collision.CompareTag("Hitbox"))
        //    {
        //        var damageable = collision.GetComponentInParent<Damageable>();
        //        m_attacker.DealDamageTo(damageable);
        //        OnCollisionWithDamageable?.Invoke();
        //    }
        //}

        private void Start()
        {
            animator = GetComponentInChildren<SkeletonAnimation>();
            m_collider = GetComponent<Collider2D>();
            animator.state.SetAnimation(0, "animation", false);
            m_currentTimer = m_delayBeforeAttack;
        }

        private void Update()
        {
            HandleDelay();
        }

        private void HandleDelay()
        {
            m_currentTimer -= Time.deltaTime;

            if(m_currentTimer <= 0)
            {
                m_collider.enabled = true;
                animator.state.AddAnimation(0, "animation2", true, 0);
            }
        }
    }
}