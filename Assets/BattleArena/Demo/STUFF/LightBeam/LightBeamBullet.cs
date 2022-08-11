using BattleArena;
using BattleArena.Gameplay.Combat;
using System;
using UnityEngine;

public class LightBeamBullet : Bullet
{
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnCollision(Collider2D collision)
    {
        base.OnCollision(collision);
    }
}
