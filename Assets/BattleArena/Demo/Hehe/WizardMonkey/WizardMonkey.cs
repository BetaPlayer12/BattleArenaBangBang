using BattleArena;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMonkey : PickupItem
{
    [SerializeField]
    private WeaponData m_weapon;
    [SerializeField]
    private GameObject m_animatedFX;

    protected override void Pickup(Collider2D collision)
    {

        var instance = Instantiate(m_animatedFX);
        instance.transform.position = Vector3.zero;

        var weapons = FindObjectsOfType<Weapon>();
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetData(m_weapon);
        }
    }
}
