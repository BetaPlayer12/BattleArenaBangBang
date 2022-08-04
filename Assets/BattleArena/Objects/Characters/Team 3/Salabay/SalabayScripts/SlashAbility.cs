using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Combat;
using BattleArena.Gameplay.Systems;
using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using Spine.Unity;

namespace BattleArena.Tests
{
    public class SlashAbility : Ability
    {
        [SerializeField, TabGroup("Animation Components")]
        private SkeletonAnimation m_animation;
        [SerializeField, TabGroup("Animation Components")]
        private SpineAnimationHolder m_animationHolder;
        [SerializeField, TabGroup("References")]
        private Transform m_parentTF;
        [SerializeField, TabGroup("Slash Components")]
        private GameObject m_slashSprite;
        [SerializeField, TabGroup("Slash Components")]
        private Attacker m_slashAttacker;
        [SerializeField, TabGroup("Slash Components")]
        private Collider2D m_slashHurtbox;
        [SerializeField, TabGroup("Slash Components")]
        private Collider2D m_deflectHitbox;
        [SerializeField, TabGroup("Slash Components")]
        private Collider2D m_destroyHitbox;
        [SerializeField, TabGroup("Slash Components")]
        private float m_slashDuration;

        private float m_timer;

        protected override void OnExecution()
        {
            //var slash = AttackerSpawner.SpawnAttacker(m_slashHurtbox, m_owner);
            //slash.transform.position = transform.position;
            //slash.transform.SetParent(this.transform);

            if (m_animation.state.GetCurrent(0).Animation.ToString() != m_animationHolder.Ability1LoopAnimation())
            {
                //Slash
                ResetSlash();
                m_animationHolder.IsBusy(false);
                StopAllCoroutines();
                StartCoroutine(TimerRoutine());
                StartCoroutine(SlashRoutine(/*slash*/));
            }
        }

        private void ResetSlash()
        {
            m_animationHolder.IsBusy(false);
            m_deflectHitbox.enabled = false;
            m_destroyHitbox.enabled = false;
            m_slashSprite.SetActive(false);
            m_timer = 0;
        }

        private IEnumerator TimerRoutine()
        {
            while (m_timer < m_slashDuration)
            {
                m_timer += Time.deltaTime;
                yield return null;
            }
            yield return null;
        }

        private IEnumerator SlashRoutine(/*GameObject slashHurtbox*/)
        {
            m_animationHolder.IsBusy(true);
            m_parentTF.rotation = Quaternion.Euler(0, 0, 90);
            m_animation.state.SetEmptyAnimation(0, 0);
            m_animation.state.SetAnimation(0, m_animationHolder.Ability1LoopAnimation(), true);
            while (m_timer < m_slashDuration)
            {
                m_slashHurtbox.enabled = true;
                m_deflectHitbox.enabled = true;
                m_destroyHitbox.enabled = true;
                m_slashSprite.SetActive(true);
                yield return new WaitForSeconds(.25f);
                //Destroy(slashHurtbox);
                m_slashHurtbox.enabled = false;
                yield return new WaitForSeconds(.25f);
                yield return null;
            }
            ResetSlash();
            yield return null;
        }

        private void Start()
        {
            m_timer = 0;
            m_slashAttacker.GetComponent<IAttacker>().SetDamage(m_owner.statInfo.strength);
        }
    }
}