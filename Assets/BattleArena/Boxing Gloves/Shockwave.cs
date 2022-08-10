using BattleArena;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : Bullet
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") Destroy(gameObject);

        if (collision.gameObject.tag == "HitBox")
        {
            var bulletObjectRigidBody = GetComponent<Rigidbody2D>();

            Vector2 difference = collision.transform.position - bulletObjectRigidBody.transform.position;
            difference = difference.normalized * 50;
            Destroy(gameObject);
            collision.rigidbody.AddForce(difference, ForceMode2D.Force);
            

        }
    }
}
