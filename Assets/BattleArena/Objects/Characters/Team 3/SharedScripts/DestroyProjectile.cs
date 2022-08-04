using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object we hit is the enemy
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null && collision.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
