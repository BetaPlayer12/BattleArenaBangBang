using BattleArena.Gameplay;
using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Combat;
using BattleArena.Gameplay.Systems;
using UnityEngine;

namespace BattleArena.Nonami.KillSwitch
{
    public class KillSwitchPickup : PickupItem
    {
        [SerializeField]
        private int m_damageValue;
        [SerializeField]
        private bool m_isGlobal;


        protected override void Pickup(Collider2D collision)
        {
           
            if (m_isGlobal)
            {
                Damageable[] Players = UnityEngine.GameObject.FindObjectsOfType<Damageable>();
                for (int i = 0; i < Players.Length; ++i)
                {
                   
                        Players[i].GetComponent<Damageable>().Heal(-m_damageValue);

                }
               
            }
        }
    }
}
