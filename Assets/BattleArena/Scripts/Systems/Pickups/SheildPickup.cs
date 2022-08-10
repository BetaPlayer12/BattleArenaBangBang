using BattleArena.Gameplay;
using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Combat;
using BattleArena.Gameplay.Systems;
using UnityEngine;

namespace BattleArena
{
    public class SheildPickup : PickupItem
    {
        [SerializeField]
        private bool m_isGlobal;

        protected override void Pickup(Collider2D collision)
        {
            collision.GetComponent<Shield>().AddValue(1);
            if (m_isGlobal)
            {
                var character = CombatManager.GetOpponentData(collision.GetComponent<Character>());
                character.shield.AddValue(1);
            }
        }
    }
}