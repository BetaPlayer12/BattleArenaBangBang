using System;
using UnityEngine;

namespace BattleArena.Gameplay.Characters
{
    public interface IAbility
    {
        void SetPower(float power);
        void SetCooldownDuration(float cooldown);
    }

    public abstract class Ability : MonoBehaviour, IAbility
    {
        public struct AbilityCooldownInfo
        {
            public AbilityCooldownInfo(float timeLeft)
            {
                this.timeLeft = timeLeft;
                this.isOnCooldown = timeLeft > 0f;
            }

            public bool isOnCooldown { get; }
            public float timeLeft { get; }
        }

        [SerializeField]
        private AbilityInfo m_info;
        protected Character m_owner;

        public event Action<AbilityCooldownInfo> OnCooldownUpdate;

        private float m_cooldownDuration;
        private float m_cooldownTimer;
        protected float power { get; private set; }
        public float cooldownDuration => m_cooldownDuration;

        public bool isOnCooldown => m_cooldownTimer > 0f;
        public AbilityInfo info => m_info;

        protected abstract void OnExecution();

        void IAbility.SetPower(float power)
        {
            this.power = power;
        }

        void IAbility.SetCooldownDuration(float cooldown)
        {
            m_cooldownDuration = cooldown;
        }

        public void Execute()
        {
            if (m_cooldownTimer <= 0)
            {
                OnExecution();
                m_cooldownTimer = m_cooldownDuration;
                OnCooldownUpdate?.Invoke(new AbilityCooldownInfo(m_cooldownTimer));
            }
        }

        public void HandleCooldown()
        {
            if (m_cooldownTimer > 0)
            {
                m_cooldownTimer -= Time.deltaTime;
                OnCooldownUpdate?.Invoke(new AbilityCooldownInfo(m_cooldownTimer));
            }
        }

        public void ResetCooldown()
        {
            m_cooldownTimer = 0;
            OnCooldownUpdate?.Invoke(new AbilityCooldownInfo(m_cooldownTimer));
        }

        private void Awake()
        {
            m_owner = GetComponentInParent<Character>();
        }

    }
}