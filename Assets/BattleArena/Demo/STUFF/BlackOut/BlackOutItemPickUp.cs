using BattleArena;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOutItemPickUp : PickupItem
{
    [SerializeField]
    private GameObject blackOutPrefab;

    protected override void Pickup(Collider2D collision)
    {
        Instantiate(blackOutPrefab, collision.transform.position, Quaternion.identity, null);
    }
}
