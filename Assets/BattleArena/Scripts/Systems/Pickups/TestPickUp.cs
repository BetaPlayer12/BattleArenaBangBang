using BattleArena.Gameplay.Combat;
using UnityEngine;

namespace BattleArena
{
    public class TestPickUp : PickupItem
    {
        [SerializeField]
        private int m_damageValue;

        protected override void Pickup(Collider2D collision)
        {
            collision.GetComponent<Damageable>().TakeDamage(m_damageValue);
        }
    }
}
