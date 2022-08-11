using BattleArena;
using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiguelGun : PickupItem
{
    [SerializeField]
    private GameObject explosionFx;
    protected override void Pickup(Collider2D collision)
    {
        GameObject explosionObject = Instantiate(explosionFx);
        explosionObject.transform.position = new Vector2(0, 0);
    }
}
