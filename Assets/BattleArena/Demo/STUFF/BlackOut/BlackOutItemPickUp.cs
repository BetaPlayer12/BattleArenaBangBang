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
        Camera maincam = GameObject.Find("Main Camera").GetComponent<Camera>();
        Instantiate(blackOutPrefab, new Vector3(maincam.transform.position.x, maincam.transform.position.y, 0), Quaternion.identity, null);
    }
}
