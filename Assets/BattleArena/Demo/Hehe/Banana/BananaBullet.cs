using BattleArena;
using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Characters.Controllers.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaBullet : Bullet
{
    [SerializeField]
    private Transform m_model;
    [SerializeField]
    private float m_modelRotation;

    protected override void OnCollision(Collider2D collision)
    {
        var character = collision.GetComponent<CharacterRotation>();
        if (character != null)
        {
            var rotation = character.currentRotation;
            character.Execute(rotation.x * -1, rotation.y * -1);
        }
        base.OnCollision(collision);
    }

    private void Update()
    {
        m_model.Rotate(0, 0, m_modelRotation);
    }
}
