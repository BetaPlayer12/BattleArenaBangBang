using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBullet : Ability
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform originPoint;

  

    public Character character;

    protected override void OnExecution()
    {
        BounceTheBullet();
    }

    public void BounceTheBullet()
    {
        var bulletProjectile = AttackerSpawner.SpawnAttacker(bullet, m_owner);
        bulletProjectile.transform.position = originPoint.position;
        var rightNormalize = originPoint.right;
        bulletProjectile.transform.right = rightNormalize;
        bulletProjectile.GetComponent<Rigidbody2D>().AddForce(rightNormalize * 70f, ForceMode2D.Impulse);
    }

}

