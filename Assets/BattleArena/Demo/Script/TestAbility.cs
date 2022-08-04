using BattleArena.Gameplay.Characters;
using UnityEngine;

namespace BattleArena.Tests
{
    public class TestAbility : Ability
    {
        [SerializeField]
        private string m_message;

        protected override void OnExecution()
        {
            Debug.Log(m_message, this);
        }
    }
}