using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena
{
    public class DamageByImpactEffect : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_impactEffect;

        private void Start()
        {
            var attacker = m_impactEffect.AddComponent<Attacker>();
            var collider = m_impactEffect.AddComponent<DamageCollider>();
        }
    }

}
