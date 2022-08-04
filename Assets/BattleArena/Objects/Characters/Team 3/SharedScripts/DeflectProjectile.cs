using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object we hit is the enemy
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null && collision.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            var cacheVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Vector3 dir = collision.transform.position - transform.position;
            dir = -dir.normalized;
            var directionalVelocity = new Vector2((collision.transform.position.x > transform.position.x ? cacheVelocity.x : -cacheVelocity.x), (collision.transform.position.y > transform.position.y ? cacheVelocity.y : -cacheVelocity.y));
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = dir * directionalVelocity;
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * cacheVelocity);
        }
    }
}
