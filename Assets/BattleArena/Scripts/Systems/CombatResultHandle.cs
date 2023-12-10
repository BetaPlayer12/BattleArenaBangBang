using BattleArena.Gameplay.Characters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay.UI
{
    public class CombatResultHandle : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_winnerName;
        [SerializeField]
        private TextMeshProUGUI m_loserName;
        [SerializeField]
        private TextMeshProUGUI m_otherMessage;
        [SerializeField]
        private Image m_winningSplashArt;
        [SerializeField]
        private Sprite m_drawImage;

        public void Display(Character winner, CharacterData winnerData, Character loser, CharacterData loserData)
        {
            if (winner == null)
            {
                m_winnerName.text = "";
                m_loserName.text = "";
                m_otherMessage.text = "DRAW!?";
                m_winningSplashArt.sprite = m_drawImage;
            }
            else
            {
                m_winnerName.text = winnerData.characterName;
                m_loserName.text = loserData.characterName;
                m_otherMessage.text = "Was Defeated By";
                m_winningSplashArt.sprite = winnerData.winningSplashArt;
            }
        }
    }
}
