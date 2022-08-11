using BattleArena;
using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeusLightning : Bullet
{
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        var damage = GetComponent<Attacker>().damage;

        foreach (Transform child in transform)
        {
            var danicaBullet = child.GetComponent<Bullet>();
            danicaBullet.GetComponent<IAttacker>().SetDamage(damage);
        }
    }

    void Update()
    {

    }

    protected override void OnCollision(Collider2D collision)
    {
        base.OnCollision(collision);
    }
}
