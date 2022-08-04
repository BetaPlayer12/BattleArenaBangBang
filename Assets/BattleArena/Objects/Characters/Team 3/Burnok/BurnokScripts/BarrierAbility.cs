using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Systems;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using Spine.Unity;

namespace BattleArena.Tests
{
    public class BarrierAbility : Ability
    {
        [SerializeField, TabGroup("Animation Components")]
        private SkeletonAnimation m_animation1;
        [SerializeField, TabGroup("Animation Components")]
        private SkeletonAnimation m_animation2;
        [SerializeField, TabGroup("Animation Components")]
        private SpineAnimationHolder m_animation1Holder;
        [SerializeField, TabGroup("Animation Components")]
        private SpineAnimationHolder m_animation2Holder;
        [SerializeField, TabGroup("References")]
        private Transform m_parentTF;
        [SerializeField, TabGroup("Barrier Components")]
        private GameObject m_barrier;

        protected override void OnExecution()
        {
            //var projectile = AttackerSpawner.SpawnAttacker(m_projectile, m_owner);
            //projectile.transform.position = m_spawnPosition.position;
            //var rightNormalize = m_spawnPosition.right;
            //projectile.transform.right = rightNormalize;
            //projectile.GetComponent<Rigidbody2D>().AddRelativeForce(rightNormalize * 50f, ForceMode2D.Impulse);
            StartCoroutine(BarrierRoutine());
            StartCoroutine(BarrierFXRoutine());
        }

        private IEnumerator BarrierRoutine()
        {
            m_parentTF.rotation = Quaternion.Euler(0, 0, 270);
            m_animation1Holder.IsBusy(true);
            m_animation2.state.SetEmptyAnimation(0, 0);
            m_animation1.state.SetAnimation(0, m_animation1Holder.Ability2LoopAnimation(), true);
            m_barrier.SetActive(true);
            yield return new WaitForSeconds(3f);
            m_animation1Holder.IsBusy(false);
            m_animation2.state.SetEmptyAnimation(0, 0);
            m_barrier.SetActive(false);
            yield return null;
        }

        private IEnumerator BarrierFXRoutine()
        {
            m_animation2.state.SetAnimation(0, m_animation2Holder.Ability1LoopAnimation(), false);
            yield return new WaitUntil(() => m_animation2.state.GetCurrent(0).IsComplete);
            m_animation2.state.SetAnimation(0, m_animation2Holder.Ability2LoopAnimation(), true);
            yield return null;
        }
    }
}