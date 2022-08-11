using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Migsplosion : MonoBehaviour
{
    [SerializeField]
    private float durationofExplosion;

    [SerializeField]
   private Attacker objectAttacker;
    void Awake()
    {
        gameObject.GetComponent<IAttacker>().SetDamage(5);
    }

    private void FixedUpdate()
    {
        var tempscale = gameObject.transform.localScale;
        durationofExplosion -= Time.deltaTime;
        tempscale.x += 0.1f;
        tempscale.y += 0.1f;
        gameObject.transform.localScale = tempscale;

        if(durationofExplosion <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox"))
        {
            var enemyDamageable = collision.gameObject.GetComponent<Damageable>();
            if(collision.rigidbody != null)
            {
                objectAttacker.DealDamageTo(enemyDamageable);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hitbox"))
        {
            var enemyDamageable = collision.gameObject.GetComponent<Damageable>();
            if (collision.rigidbody != null)
            {
                objectAttacker.DealDamageTo(enemyDamageable);
            }
        }
    }

}
