using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena
{
    public class DamageByImpactEffect : MonoBehaviour
    {
        private void Start()
        {
            var attacker = gameObject.AddComponent<Attacker>();
            var collider = gameObject.AddComponent<DamageCollider>();
        }
    }

}
