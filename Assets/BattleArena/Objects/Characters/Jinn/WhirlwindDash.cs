using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Characters.Controllers;
using BattleArena.Gameplay.Characters.Controllers.Modules;
using BattleArena.Gameplay.Systems;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlwindDash : Ability
{
    [SerializeField]
    private float m_dashDuration;
    [SerializeField]
    private float m_dashForce;
    [SerializeField]
    private Transform m_model;
    [SerializeField]
    private SkeletonAnimation animator;
    [SerializeField]
    private Collider2D m_damageCollider;
    [SerializeField]
    private GameObject m_damagingStuff;
    [SerializeField]
    private GameObject m_spawnPoint;

    [SerializeField]
    private GameObject m_projectile;
    [SerializeField]
    private Transform[] m_projectileSpawn;

    private Rigidbody2D m_rigidBody;
    private float m_dashTimer;
    private bool m_dashing;
    private Collider2D m_playerCollider;
    private CharacterBaseController controller;
    private GameObject attackGameObject;
    private bool hasSpawnedAttack;

    protected override void OnExecution()
    {
        controller.enabled = false;
        m_dashing = true;

        //animator.state.SetAnimation(0, "Attack_2", true);
        //animator.state.Complete += State_Complete2;
        //var projectile = AttackerSpawner.SpawnAttacker(m_projectile, m_owner);
        //projectile.transform.position = m_projectileSpawn.position;
        //var rightNormalize = m_projectileSpawn.right;
        //projectile.transform.right = rightNormalize;
        //projectile.GetComponent<Rigidbody2D>().AddRelativeForce(rightNormalize * 50f, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (m_dashing == true)
        {
            HandleDash();
        }
    }

    private void HandleDash()
    {
        if (m_dashTimer > 0)
        {
            if (hasSpawnedAttack == false)
            {
                attackGameObject = AttackerSpawner.SpawnAttacker(m_damagingStuff, m_owner);
                attackGameObject.transform.position = m_spawnPoint.transform.position;
                attackGameObject.transform.SetParent(m_spawnPoint.transform);

                animator.state.SetAnimation(0, "Attack_1", false);
                animator.state.Complete += State_Complete;

                hasSpawnedAttack = true;
            }

            m_rigidBody.velocity = Vector2.zero;
            m_rigidBody.velocity = m_model.transform.right * m_dashForce;

            m_dashTimer -= Time.deltaTime;

            //if(m_dashTimer <= (m_dashDuration / 2))
            //{
            //    if(hasSpawnedAttack == false)
            //    {
            //        //attackGameObject = AttackerSpawner.SpawnAttacker(m_damagingStuff, m_owner);
            //        //attackGameObject.transform.position = m_spawnPoint.transform.position;
            //        //attackGameObject.transform.SetParent(m_spawnPoint.transform);

            //        animator.state.SetAnimation(0, "Attack_1", false);
            //        animator.state.Complete += State_Complete;

            //        hasSpawnedAttack = true;
            //    }
            //}
            if (m_dashTimer <= 0)
            {
                controller.enabled = true;
                m_dashing = false;
                m_dashTimer = m_dashDuration;
                animator.state.AddAnimation(0, "Move", true, 0);

                //foreach (Transform trans in m_projectileSpawn)
                //{
                //    var projectile = AttackerSpawner.SpawnAttacker(m_projectile, m_owner);
                //    projectile.transform.position = trans.position;
                //    var rightNormalize = trans.right;
                //    projectile.transform.right = rightNormalize;
                //    projectile.GetComponent<Rigidbody2D>().AddRelativeForce(rightNormalize * 50f, ForceMode2D.Impulse);
                //}
            }
        }
        else
        {
            controller.enabled = true;
            m_dashing = false;
            m_dashTimer = m_dashDuration;

            attackGameObject = AttackerSpawner.SpawnAttacker(m_damagingStuff, m_owner);
            attackGameObject.transform.position = m_spawnPoint.transform.position;
            attackGameObject.transform.SetParent(m_spawnPoint.transform);
            
            animator.state.SetAnimation(0, "Attack_1", false);
            animator.state.Complete += State_Complete;
            animator.state.AddAnimation(0, "Move", true, 0);
        }
    }

    private void State_Complete(Spine.TrackEntry trackEntry)
    {
        Destroy(attackGameObject);
        hasSpawnedAttack = false;
    }

    private void State_Complete2(Spine.TrackEntry trackEntry)
    {
        animator.state.AddAnimation(0, "Move", true, 0);
    }

    void Start()
    {
        controller = GetComponentInParent<CharacterBaseController>();
        m_rigidBody = GetComponentInParent<Rigidbody2D>();

        m_dashTimer = m_dashDuration;
    }
}
