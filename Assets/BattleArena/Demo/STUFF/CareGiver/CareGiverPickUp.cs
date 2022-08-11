using BattleArena;
using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareGiverPickUp : PickupItem
{
    [SerializeField]
    private GameObject shield;

    protected override void Pickup(Collider2D collision)
    {
        //Instantiate(shield, collision.gameObject.transform);

        //var character = CombatManager.GetOpponentData(collision.GetComponent<Character>());

        Character[] list = FindObjectsOfType(typeof(Character)) as Character[];
        foreach (Character obj in list)
        {
            Instantiate(shield, obj.gameObject.transform);          
        }

        //Instantiate(shield, character.gameObject.transform);
        //character.shield.AddValue(1);
    }
}
