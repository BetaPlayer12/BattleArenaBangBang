using BattleArena;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonXi : Bullet
{
    float duration = 3f;
    private void DragonLifeEnd()
    {
        Destroy(gameObject);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var bulletObjectRigidBody = GetComponent<Rigidbody2D>();

        if (collision.gameObject.tag == "Wall")
        {
            Vector2 difference = collision.transform.position - bulletObjectRigidBody.transform.position;
            difference = difference.normalized * 80;
            bulletObjectRigidBody.AddForce(difference, ForceMode2D.Impulse);
        }

        if (collision.gameObject.tag == "HitBox")
        {
            Vector2 difference = collision.transform.position - bulletObjectRigidBody.transform.position;
            difference = difference.normalized * 2;
            collision.rigidbody.AddForce(difference, ForceMode2D.Impulse);
        }
        
    }
    private void FixedUpdate()
    {
        duration -= Time.deltaTime;
        Debug.Log(duration);
        MoveBullet();
        if(duration <= 0)
        {
            DragonLifeEnd();
        }
    }

}
