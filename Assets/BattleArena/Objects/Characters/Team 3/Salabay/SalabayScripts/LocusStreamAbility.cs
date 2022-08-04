using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Characters.Controllers.Modules;
using BattleArena.Gameplay.Systems;
using System.Collections;
using UnityEngine;
using Spine.Unity;
using Sirenix.OdinInspector;

namespace BattleArena.Tests
{
    public class LocusStreamAbility : Ability
    {
        [SerializeField, TabGroup("Animation Components")]
        private SkeletonAnimation m_animation;
        [SerializeField, TabGroup("Animation Components")]
        private SpineAnimationHolder m_animationHolder;
        [SerializeField, TabGroup("References")]
        private Transform m_parent;
        [SerializeField, TabGroup("References")]
        private CharacterMovement m_movement;
        [SerializeField, TabGroup("References")]
        private Rigidbody2D m_rigidbody2D;
        [SerializeField, TabGroup("References")]
        private Collider2D m_bodyHitbox;
        [SerializeField, TabGroup("FX")]
        private ParticleSystem m_fx;
        [SerializeField, TabGroup("Dash Components")]
        private float m_dashForce;

        private Coroutine m_dashCoroutine;

        protected override void OnExecution()
        {
            if (!m_bodyHitbox.IsTouchingLayers(LayerMask.NameToLayer("Default")))
            {
                m_dashCoroutine = StartCoroutine(DashRoutine());
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                ResetPosition(transform.position);
                //StopAllCoroutines();
                StopCoroutine(m_dashCoroutine);
            }
        }

        private IEnumerator DetectWallsRoutine()
        {
            while (true)
            {
                if (m_bodyHitbox.IsTouchingLayers(LayerMask.NameToLayer("Default")))
                {
                    ResetPosition(transform.position);
                    //StopAllCoroutines();
                    StopCoroutine(m_dashCoroutine);
                }
                yield return null;
            }
        }

        private IEnumerator DashRoutine()
        {
            float time = 0;
            var horizontalAxis = m_rigidbody2D.velocity.x > 0 ? 1 : -1;
            if (m_rigidbody2D.velocity.x == 0)
            {
                horizontalAxis = 0;
            }
            var verticalAxis = m_rigidbody2D.velocity.y > 0 ? 1 : -1;
            if (m_rigidbody2D.velocity.y == 0)
            {
                verticalAxis = 0;
            }
            m_fx.Play();
            if (m_animationHolder.CanDoAction())
            {
                m_animationHolder.IsBusy(true);
                //m_parent.rotation = Quaternion.identity;
                m_animation.state.SetEmptyAnimation(0, 0);
                m_animation.state.SetAnimation(0, m_animationHolder.Ability2LoopAnimation(), true);
            }
            while (time < .15f)
            {
                m_movement.Cancel();
                m_parent.position = new Vector2(m_parent.position.x + (m_dashForce * horizontalAxis), m_parent.position.y + (m_dashForce * verticalAxis));
                time += Time.deltaTime;
                yield return null;
            }
            m_fx.Stop();
            if (m_animation.state.GetCurrent(0).Animation.ToString() == m_animationHolder.Ability2LoopAnimation())
            {
                m_animationHolder.IsBusy(false);
            }
            //yield return new WaitForSeconds(.25f);
            //m_rigidbody2D.velocity = Vector2.zero;
            yield return null;
        }

        private void ResetPosition(Vector2 pos)
        {
            m_parent.position = pos;
            m_fx.Stop();
            if (m_animation.state.GetCurrent(0).Animation.ToString() == m_animationHolder.Ability2LoopAnimation())
            {
                m_animationHolder.IsBusy(false);
            }
        }

        private void Start()
        {
            StartCoroutine(DetectWallsRoutine());
        }
    }
}