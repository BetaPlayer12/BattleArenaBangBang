using Sirenix.OdinInspector;
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

        [Button]
        protected abstract void Pickup(Collider2D collision);

        private void Update()
        {
            m_lifeTime -= Time.deltaTime;
            if(m_lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Hitbox"))
            {
                Pickup(collision);
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            PickedUp?.Invoke(this);
        }
    }
}