using BattleArena.Gameplay.Combat;
using UnityEngine;

namespace BattleArena
{
    public class HealthPickup : PickupItem
    {
        [SerializeField]
        private int m_healValue;

        protected override void Pickup(Collider2D collision)
        {
            collision.GetComponent<Damageable>().Heal(m_healValue);
        }
    }
}