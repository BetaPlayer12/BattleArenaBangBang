using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena.Gameplay
{
    public class Lifespan : MonoBehaviour
    {
        [SerializeField]
        private float m_lifeTimeInSeconds;
        [SerializeField]
        private Bullet m_bullet;

        private void Update()
        {
            m_lifeTimeInSeconds -= Time.deltaTime;

            if (m_lifeTimeInSeconds <= 0)
                m_bullet.ForceCollision();
        }
    }

}
