using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Systems;
using Spine.Unity;
using UnityEngine;

namespace BattleArena.Tests
{
    public class LunarCleaveAbility : Ability
    {
        [SerializeField]
        private GameObject m_projectile;
        [SerializeField]
        private Transform m_spawnPosition;
        [SerializeField]
        private SkeletonAnimation anim;
        protected override void OnExecution()
        {
            anim.state.SetAnimation(0, "attack_animation", false);
            anim.state.Complete += State_Complete;
            var projectile = AttackerSpawner.SpawnAttacker(m_projectile, m_owner);
            projectile.transform.position = m_spawnPosition.position;
            var rightNormalize = m_spawnPosition.right;
            projectile.transform.right = rightNormalize;
            projectile.GetComponent<Rigidbody2D>().AddRelativeForce(rightNormalize * 50f, ForceMode2D.Impulse);
        }
        private void State_Complete(Spine.TrackEntry trackEntry)
        {
            anim.state.AddAnimation(0, "walk cycle", true, 0);

        }
    }
}
