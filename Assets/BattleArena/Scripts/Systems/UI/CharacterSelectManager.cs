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
        [SerializeField]
        private Image m_startCombatButtonBackground;
        [SerializeField]
        private Color m_notReadyForCombatColor;
        [SerializeField]
        private Color m_readyForCombatColor;
        [SerializeField]
        private Image m_lightningReady;

        public InitializationCommand CreateCharacterInitializationCommand() => new InitializationCommand(m_player1.GetSelectedCharacter(), m_player2.GetSelectedCharacter());

        private void OnPlayerReadinessChange()
        {
            m_startCombatButton.interactable = m_player1.isReady && m_player2.isReady;
            if (m_startCombatButton.interactable)
            {
                m_startCombatButtonBackground.color = m_readyForCombatColor;
                m_lightningReady.gameObject.SetActive(true);
            }
            else
            {
                m_startCombatButtonBackground.color = m_notReadyForCombatColor;
                m_lightningReady.gameObject.SetActive(false);
            }
        }

        public void Reset()
        {
            m_player1.Reset();
            m_player2.Reset();
            m_startCombatButtonBackground.color = m_notReadyForCombatColor;
            m_lightningReady.gameObject.SetActive(false);
        }

        private void Awake()
        {
            m_player1.ReadinessChange += OnPlayerReadinessChange;
            m_player2.ReadinessChange += OnPlayerReadinessChange;
            m_lightningReady.gameObject.SetActive(false);
        }

    }
}
