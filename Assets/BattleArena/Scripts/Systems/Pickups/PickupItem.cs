using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena
{
    public abstract class PickupItem : MonoBehaviour
    {
        [SerializeField]
        private float m_lifeTime;

        public event Action<PickupItem> PickedUp;

        protected abstract void Pickup(Collider2D collision);

        private void Update()
        {
            m_lifeTime -= Time.deltaTime;
            if(m_lifeTime <= 0)
            {
                PickedUp?.Invoke(this);
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Hitbox"))
            {
                Pickup(collision);
                PickedUp?.Invoke(this);
                Destroy(gameObject);
            }
        }
    }
}