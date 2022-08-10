using BattleArena.Gameplay.Combat;
using UnityEngine;

namespace BattleArena
{
    public class PewMechanism : FiringMechanism
    {
        [SerializeField]
        private PewMechanismData m_data;
        private float m_firingRate;
        private int m_bulletDamage;
        private float m_bulletSpeed;

        private float cooldownDuration => 1f / (m_data.firingRate + m_firingRate);
        private float m_cooldownTimer = 0;

        public PewMechanism(PewMechanismData data)
        {
            m_data = data;
        }

        public override bool isOnCooldown => m_cooldownTimer > 0;

        public override bool needsToBeCharged => false;

        public void SetData(PewMechanismData data)
        {
            m_data = data;
        }

        public override void Charge(float delta)
        {
        }
        public override void Fire(Vector3 startPosition, Vector3 rotation)
        {
            if (m_data.muzzleFireFX != null)
            {
                var muzzleFire = GameObject.Instantiate(m_data.muzzleFireFX);
                muzzleFire.transform.position = startPosition;
                muzzleFire.transform.right = rotation;
            }
            var bullet = GameObject.Instantiate(m_data.bullet).GetComponent<Bullet>();
            bullet.transform.position = startPosition;
            bullet.transform.right = rotation;
            bullet.gameObject.layer = m_physicsLayer;

            bullet.SetSpeed(m_data.bulletSpeed + m_bulletSpeed);
            bullet.GetComponent<IAttacker>().SetDamage(m_data.bulletDamage + m_bulletDamage);
            m_cooldownTimer = cooldownDuration;
        }

        public override void HandleCooldown(float delta)
        {
            m_cooldownTimer -= delta;
        }

        public override void AddStat(BulletStatData bulletStatData)
        {
            m_firingRate += bulletStatData.firingRate;
            m_bulletDamage += bulletStatData.bulletDamage;
            m_bulletSpeed += bulletStatData.bulletSpeed;
        }
    }

}