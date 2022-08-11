using BattleArena.Gameplay;
using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Combat;
using BattleArena.Gameplay.Systems;
using UnityEngine;

namespace BattleArena.Nonami.FireRateUp
{
    public class FireRatePickUp : PickupItem
    {
        [SerializeField]
        private BulletStatData m_additionalStat;

        protected override void Pickup(Collider2D collision)
        {
            collision.GetComponent<Weapon>().AddData(m_additionalStat);
        }
    }
}