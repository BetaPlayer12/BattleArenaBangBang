using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Characters.Controllers;
using BattleArena.Gameplay.Characters.Controllers.Modules;
using BattleArena.Gameplay.Combat;
using BattleArena.Gameplay.Systems;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isekai : Ability
{
    

    Attacker attacker;
    [SerializeField]
    private Transform transformParent;
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private CharacterMovement m_movement;
    Rigidbody2D rb2d;
    public event Action OnCollisionWithDamageable;

    CharacterStatInfo info;
    protected override void OnExecution()
    {
        StartCoroutine(DashRoutine());
    }

   

    private IEnumerator DashRoutine()
    {
        float time = 0;
        var horizontalAxis = Input.GetAxisRaw("Horizontal");
        var verticalAxis = Input.GetAxisRaw("Vertical");
        while (time < 0.09f)
        {
            m_movement.Cancel();
            transformParent.position = new Vector2(transformParent.position.x + (dashSpeed * horizontalAxis), transformParent.position.y + (dashSpeed * verticalAxis));
            time += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
  
    private void Awake()
    {
        attacker = GetComponentInParent<Attacker>(); 
        rb2d = GetComponentInParent<Rigidbody2D>();

    }
}
