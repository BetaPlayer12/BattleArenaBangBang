using BattleArena.Gameplay.Characters;
using TMPro;
using UnityEngine;

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

        public void Display(Character winner, CharacterData winnerData, Character loser, CharacterData loserData)
        {
            if (winner == null)
            {
                m_winnerName.text = "";
                m_loserName.text = "";
                m_otherMessage.text = "DRAW!?";
            }
            else
            {
                m_winnerName.text = winnerData.characterName;
                m_loserName.text = loserData.characterName;
                m_otherMessage.text = "Was Defeated By";
            }
        }
    }
}
