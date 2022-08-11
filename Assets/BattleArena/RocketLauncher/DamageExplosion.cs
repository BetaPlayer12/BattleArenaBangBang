using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageExplosion : MonoBehaviour
{
    [SerializeField]
    private Attacker m_attacker;

    public Attacker attacker { get { return m_attacker; } set { m_attacker = value; } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox"))
        {
            var enemyDamage = collision.gameObject.GetComponent<Damageable>();
            if (collision.rigidbody != null)
            {
                    m_attacker.DealDamageTo(enemyDamage);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox"))
        {
            var enemyDamage = collision.gameObject.GetComponent<Damageable>();
            if (collision.rigidbody != null)
            {
                m_attacker.DealDamageTo(enemyDamage);
            }
        }
    }

}
