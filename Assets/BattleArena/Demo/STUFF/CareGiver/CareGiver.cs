using BattleArena;
using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareGiver : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem healFx;

    private int healValue;

    void Start()
    {
        healValue = 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            var bulletDamage = collision.GetComponent<Attacker>().damage;
            gameObject.GetComponentInParent<Damageable>().Heal(bulletDamage + healValue);
            healValue += 5;
            Instantiate(healFx, transform);
            //healFx.Play();
            //Destroy(collision.gameObject);
        }
    }
}
