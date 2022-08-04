using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Combat;
using BattleArena.Gameplay.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MichaelAngelowShield : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D reflectorRb2d;

    [SerializeField]
    GameObject kero;

    [SerializeField]
    GameObject bullet;

    Vector2 reflector;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AttackerSpawner.IgnoreCollision(kero, bullet);
    }


}
