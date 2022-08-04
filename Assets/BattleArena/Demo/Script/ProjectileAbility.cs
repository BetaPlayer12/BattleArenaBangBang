using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Systems;
using UnityEngine;

namespace BattleArena.Tests
{
    public class ProjectileAbility : Ability
    {
        [SerializeField]
        private GameObject m_projectile;
        [SerializeField]
        private Transform m_spawnPosition;

        protected override void OnExecution()
        {
            var projectile = AttackerSpawner.SpawnAttacker(m_projectile, m_owner);
            projectile.transform.position = m_spawnPosition.position;
            var rightNormalize = m_spawnPosition.right;
            projectile.transform.right = rightNormalize;
            projectile.GetComponent<Rigidbody2D>().AddRelativeForce(rightNormalize * 50f, ForceMode2D.Impulse);
        }
    }
}