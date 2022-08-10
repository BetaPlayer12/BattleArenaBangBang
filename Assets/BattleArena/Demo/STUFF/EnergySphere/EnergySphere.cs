using BattleArena;
using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySphere : Bullet
{
    [SerializeField]
    private LayerMask layer;

    private float lifeTimer;
    private float currentLifeTimer;

    void Start()
    {
        Initialize();
        lifeTimer = 3;
    }

    private void Initialize()
    {
        var damage = GetComponent<Attacker>().damage;

        foreach (Transform child in transform)
        {
            var danicaBullet = child.GetComponent<Bullet>();
            if (danicaBullet != null)
            {
                danicaBullet.GetComponent<IAttacker>().SetDamage(damage);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform)
        {
            var danicaBullet = child.GetComponent<Rigidbody2D>();
            if (danicaBullet != null)
            {
                danicaBullet.velocity /= 2;
            }
        }

        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnCollision(Collider2D collision)
    {
        base.OnCollision(collision);
        LayerMask enemy = LayerMask.GetMask("Player 2");

        Collider2D collider = Physics2D.OverlapCircle(transform.position, 10, layer);

        if (collider != null)
        {
            Debug.Log("Player 2 found!");

            if (transform.position.x > collider.transform.position.x)
            {
                collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * -20, ForceMode2D.Force);
            }
            else
            {
                collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 20, ForceMode2D.Force);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 10);
    }
}
