using BattleArena;
using BattleArena.Gameplay.Characters.Controllers.Modules;
using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipShield : PickupItem
{
    [SerializeField]
    private GameObject whipshieldObject;
    protected override void Pickup(Collider2D collision)
    {
        var gameObjects = FindObjectsOfType<CharacterRotation>();
        for (int i = 0; i < gameObjects.Length; i++)
        {
            var shieldInst = Instantiate(whipshieldObject);
            shieldInst.transform.position = gameObjects[i].transform.position;
            shieldInst.transform.parent = gameObjects[i].transform;
        }
        
    }
}
