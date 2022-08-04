using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Characters.Controllers;
using BattleArena.Gameplay.Systems;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roar : Ability
{
    [SerializeField]
    private GameObject m_attackPrefab;
    [SerializeField]
    private Transform m_spawnPosition;
    [SerializeField]
    private float m_timer;
    [SerializeField]
    private SkeletonAnimation animator;
    [SerializeField]
    private Ability ability;

    private float currentTimer;
    private bool tickTimer;
    private CharacterBaseController controller;
    private GameObject attack;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        controller = GetComponentInParent<CharacterBaseController>();
        rigidBody = GetComponentInParent<Rigidbody2D>();
        currentTimer = m_timer;
        tickTimer = false;
    }

    private void Update()
    {
        HandleTimer();
    }

    private void HandleTimer()
    {
        if (tickTimer == true)
        {
            currentTimer -= Time.deltaTime;
            if(currentTimer <= 0)
            {
                Destroy(attack);
                currentTimer = m_timer;
                tickTimer = false;
            }
        }
    }

    protected override void OnExecution()
    {
        animator.state.SetAnimation(0, "Attack_2", false);
        animator.state.Complete += State_Complete;
        //controller.enabled = false;
        rigidBody.velocity = Vector2.zero;

        attack = AttackerSpawner.SpawnAttacker(m_attackPrefab, m_owner);
        attack.transform.position = m_spawnPosition.position;

        var rightNormalize = m_spawnPosition.right;
        attack.transform.right = rightNormalize;
        attack.GetComponent<Rigidbody2D>().AddRelativeForce(rightNormalize * 0f, ForceMode2D.Impulse);

        tickTimer = true;
        if(ability != null)
        {
            ability.ResetCooldown();
        }
    }

    private void State_Complete(Spine.TrackEntry trackEntry)
    {
        animator.state.AddAnimation(0, "move", true, 0);
        //controller.enabled = true;
    }
}
