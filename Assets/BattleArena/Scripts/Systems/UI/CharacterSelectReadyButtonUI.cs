using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay.UI
{
    public class CharacterSelectReadyButtonUI : MonoBehaviour
    {
        [SerializeField]
        private Image m_button;
        [SerializeField]
        private TextMeshProUGUI m_buttonText;
        private bool m_hasDisplayedIsReady;

        public void DisplayIsReady(bool isTrue)
        {
            if (isTrue)
            {
                if (m_hasDisplayedIsReady)
                {
                    m_buttonText.text = "Definitely Ready!!!";
                }
                else
                {
                    m_buttonText.text = "Ready!";
                    m_hasDisplayedIsReady = true;
                }
            }
            else
            {
                if (m_hasDisplayedIsReady)
                {
                    m_buttonText.text = "Clearly Not Ready";
                }
                else
                {
                    m_buttonText.text = "Not Ready";
                }
            }
        }

        public void Reset()
        {
            m_hasDisplayedIsReady = false;
            DisplayIsReady(false);
        }
    }
}
