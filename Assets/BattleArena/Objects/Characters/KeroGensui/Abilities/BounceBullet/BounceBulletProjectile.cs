using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBulletProjectile : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    Rigidbody2D bulletBody;

    public void BounceOff()
    {
        Vector3 bulletdir = new Vector3(0, 0, 35);
        bullet.transform.TransformDirection(bulletdir);

        bulletBody.AddForce(bulletdir * 50f, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            BounceOff();
        }
    }
}
