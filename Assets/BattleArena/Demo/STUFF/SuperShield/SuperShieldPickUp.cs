using BattleArena;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShieldPickUp : PickupItem
{
    [SerializeField]
    private GameObject shield;

    protected override void Pickup(Collider2D collision)
    {
        Instantiate(shield, collision.gameObject.transform);
    }
}
