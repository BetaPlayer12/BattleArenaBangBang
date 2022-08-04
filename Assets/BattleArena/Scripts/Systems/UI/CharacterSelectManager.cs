using BattleArena.Gameplay.Systems;
using BattleArena.Gameplay.UI;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay.Menu
{
    public class CharacterSelectManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerManager m_playerManager;
        [SerializeField]
        private CharacterSelectHandle m_player1;
        [SerializeField]
        private CharacterSelectHandle m_player2;
        [SerializeField]
        private Button m_startCombatButton;

        public InitializationCommand CreateCharacterInitializationCommand() => new InitializationCommand(m_player1.GetSelectedCharacter(), m_player2.GetSelectedCharacter());

        private void OnPlayerReadinessChange()
        {
            m_startCombatButton.interactable = m_player1.isReady && m_player2.isReady;
        }

        public void Reset()
        {
            m_player1.Reset();
            m_player2.Reset();
        }

        private void Awake()
        {
            m_player1.ReadinessChange += OnPlayerReadinessChange;
            m_player2.ReadinessChange += OnPlayerReadinessChange;
        }

    }
}
