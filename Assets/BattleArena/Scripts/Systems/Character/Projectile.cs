using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena
{
    public class Projectile : MonoBehaviour
    {
        protected virtual void CollideWithEnvironment()
        {
            Destroy(gameObject);
        }
        protected virtual void CollideWithDamageable()
        {
            Destroy(gameObject);
        }

        protected void HandleEnvironmentCollision(Collider2D collision)
        {
            if (LayerMask.LayerToName(collision.gameObject.layer) == "Default")
            {
                CollideWithEnvironment();
            }
        }

        protected virtual void Awake()
        {
            var damageColliders = GetComponentsInChildren<DamageCollider>();
            foreach (var collider in damageColliders)
            {
                collider.OnCollisionWithDamageable += CollideWithDamageable;
            }
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            HandleEnvironmentCollision(collision);
        }

        protected virtual void OnDestroy()
        {
            var damageColliders = GetComponentsInChildren<DamageCollider>();
            foreach (var collider in damageColliders)
            {
                collider.OnCollisionWithDamageable -= CollideWithDamageable;
            }
        }
    }

}