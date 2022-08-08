using Sirenix.OdinInspector;
using UnityEngine;

namespace BattleArena
{
    [System.Serializable]
    public class PewMechanismData
    {
        [SerializeField]
        private GameObject m_muzzleFireFX;
        [SerializeField]
        private GameObject m_bullet;
        [SerializeField,ReadOnly]
        private int m_allocatedPoints = 10;
        [SerializeField,ReadOnly,HorizontalGroup("Bullet Speed")]
        private float m_bulletSpeed = 25;
        [SerializeField, ReadOnly, HorizontalGroup("Bullet Damage")]
        private int m_bulletDamage = 5;
        [SerializeField, ReadOnly, HorizontalGroup("Firing Rate")]
        private float m_firingRate = 1.2f;

        private const float BULLETSPEED_INCREMENTS = 1.5f;
        private const float BULLETSPEED_MINVALUE = 15;
        private const float BULLETSPEED_MAXVALUE = 49;
        private const int BULLETDAMAGE_INCREMENTS = 2;
        private const float BULLETDAMAGE_MINVALUE = 1;
        private const float BULLETDAMAGE_MAXVALUE = 20;
        private const float FIRINGRATE_INCREMENTS = 0.2f;
        private const float FIRINGRATE_MINVALUE = 0.6f;
        private const float FIRINGRATE_MAXVALUE = 3.5f;


        public GameObject muzzleFireFX => m_muzzleFireFX;
        public GameObject bullet => m_bullet;
        public float bulletSpeed => m_bulletSpeed;
        public int bulletDamage => m_bulletDamage;
        public float firingRate => m_firingRate;

        [Button]
        private void Reset()
        {
            m_allocatedPoints = 10;
            m_bulletSpeed = 25;
            m_bulletDamage = 5;
            m_firingRate = 1.2f;
        }

        [Button("-"), HorizontalGroup("Bullet Speed")]
        private void ReduceBulletSpeed()
        {
            if (m_bulletSpeed > BULLETSPEED_MINVALUE)
            {
                m_bulletSpeed -= BULLETSPEED_INCREMENTS;
                m_allocatedPoints++;
            }
        }
        [Button("+"), HorizontalGroup("Bullet Speed")]
        private void AddBulletSpeed()
        {
            if (m_allocatedPoints > 0 && m_bulletSpeed < BULLETSPEED_MAXVALUE)
            {
                m_bulletSpeed += BULLETSPEED_INCREMENTS;
                m_allocatedPoints--;
            }
        }

        [Button("-"), HorizontalGroup("Bullet Damage")]
        private void ReduceBulletDamage()
        {
            if (m_bulletDamage > BULLETDAMAGE_MINVALUE)
            {
                m_bulletDamage -= BULLETDAMAGE_INCREMENTS;
                m_allocatedPoints++;
            }
        }
        [Button("+"), HorizontalGroup("Bullet Damage")]
        private void AddBulletDamage()
        {
            if (m_allocatedPoints > 0 && m_bulletDamage < BULLETDAMAGE_MAXVALUE)
            {
                m_bulletDamage += BULLETDAMAGE_INCREMENTS;
                m_allocatedPoints--;
            }
            
        }

        [Button("-"), HorizontalGroup("Firing Rate")]
        private void ReduceFiringRate()
        {
            if (m_firingRate > FIRINGRATE_MINVALUE)
            {
                m_firingRate -= FIRINGRATE_INCREMENTS;
                m_allocatedPoints++;
            }
        }
        [Button("+"), HorizontalGroup("Firing Rate")]
        private void AddFiringRate()
        {
            if (m_allocatedPoints > 0 && m_firingRate < FIRINGRATE_MAXVALUE)
            {
                m_firingRate += FIRINGRATE_INCREMENTS;
                m_allocatedPoints--;
            }
        }
    }

}