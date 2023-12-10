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
        [SerializeField]
        private GameObject m_shieldVisual;

        protected override void Pickup(Collider2D collision)
        {
            var currentshield = collision.GetComponent<Shield>();
            currentshield.AddValue(1);
            currentshield.SetSheildVisuals(m_shieldVisual);
            if (m_isGlobal)
            {
                var character = CombatManager.GetOpponentData(collision.GetComponent<Character>());
                character.shield.AddValue(1);
                character.shield.SetSheildVisuals(m_shieldVisual);
            }
        }
    }
}