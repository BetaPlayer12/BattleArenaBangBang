using BattleArena.Gameplay;
using UnityEngine;

namespace BattleArena.Tests
{
    public class TestPlayerIntialization : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_player1;
        [SerializeField]
        private GameObject m_player2;

        private void Awake()
        {
            //PlayerManager.SetPlayersToInitialize(new Gameplay.Systems.InitializationCommand(m_player1, m_player2));
        }
    }
}