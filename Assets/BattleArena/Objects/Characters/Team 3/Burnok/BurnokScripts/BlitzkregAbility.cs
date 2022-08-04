using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Spine.Unity;

namespace BattleArena.Tests
{
    public class BlitzkregAbility : Ability
    {
        [SerializeField, TabGroup("Animation Components")]
        private SkeletonAnimation m_animation;
        [SerializeField, TabGroup("Animation Components")]
        private SpineAnimationHolder m_animationHolder;
        [SerializeField, TabGroup("References")]
        private GameObject m_projectile;
        [SerializeField, TabGroup("References")]
        private Transform m_parentTF;
        [SerializeField, TabGroup("References")]
        private Transform m_spawnPosition;
        [SerializeField, TabGroup("References")]
        private float m_blitzkregDuration;
        [SerializeField, TabGroup("References")]
        private GameObject m_barrier;

        private float m_timer;

        protected override void OnExecution()
        {
            //var projectile = AttackerSpawner.SpawnAttacker(m_projectile, m_owner);
            //projectile.transform.position = m_spawnPosition.position;
            //var rightNormalize = m_spawnPosition.right;
            //projectile.transform.right = rightNormalize;
            //projectile.GetComponent<Rigidbody2D>().AddRelativeForce(rightNormalize * 50f, ForceMode2D.Impulse);
            StartCoroutine(TimerRoutine());
            StartCoroutine(BlitzkregRoutine(16));
        }

        private IEnumerator TimerRoutine()
        {
            while (m_timer < m_blitzkregDuration)
            {
                m_timer += Time.deltaTime;
                yield return null;
            }
            yield return null;
        }

        private IEnumerator BlitzkregRoutine(int numberOfProjectiles)
        {
            //for (int x = 0; x < rotations; x++)
            //{
            //}
            m_parentTF.rotation = Quaternion.Euler(0, 0, 270);
            m_animationHolder.IsBusy(true);
            m_animation.state.SetEmptyAnimation(0, 0);
            m_animation.state.SetAnimation(0, m_animationHolder.Ability1LoopAnimation(), true);
            while (m_timer < m_blitzkregDuration)
            {
                List<GameObject> projectiles = new List<GameObject>();
                float angleStep = 360f / numberOfProjectiles;
                float angle = 0f;
                for (int y = 0; y < 2; y++)
                {
                    if (y == 1)
                    {
                        angle = 69; //( ͡° ͜ʖ ͡°) hihi
                    }
                    for (int z = 0; z < numberOfProjectiles; z++)
                    {
                        Vector2 startPoint = new Vector2(m_spawnPosition.position.x, m_spawnPosition.position.y);
                        float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * 5;
                        float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * 5;

                        Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
                        Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * 50f;

                        var projectile = AttackerSpawner.SpawnAttacker(m_projectile, m_owner);
                        projectile.transform.position = m_spawnPosition.position;
                        projectile.GetComponent<Rigidbody2D>().velocity = projectileMoveDirection;
                        Vector2 v = projectile.GetComponent<Rigidbody2D>().velocity;
                        var projRotation = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
                        projectile.transform.rotation = Quaternion.AngleAxis(projRotation, Vector3.forward);
                        projectiles.Add(projectile);
                        //yield return new WaitForSeconds(.15f);
                        //projectile.GetComponent<Collider2D>().enabled = true;

                        angle += angleStep;
                    }
                    yield return new WaitForSeconds(!m_barrier.activeSelf ? .15f : .5f);
                    for (int i = 0; i < projectiles.Count; i++)
                    {
                        projectiles[i].GetComponent<Collider2D>().enabled = true;
                    }
                    projectiles.Clear();
                    yield return new WaitForSeconds(!m_barrier.activeSelf ? .5f : .15f);
                }
                //yield return new WaitForSeconds(1);
                yield return null;
            }
            m_timer = 0;
            m_animationHolder.IsBusy(false);
            yield return null;
        }

        private void Start()
        {
            m_timer = 0;
        }
    }
}