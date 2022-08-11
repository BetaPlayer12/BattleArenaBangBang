using UnityEngine;

namespace BattleArena
{
    public class StatUpPickup : PickupItem
    {
        [SerializeField]
        private BulletStatData m_additionalStat;

        protected override void Pickup(Collider2D collision)
        {
            collision.GetComponent<Weapon>().AddData(m_additionalStat);
        }
    }
}