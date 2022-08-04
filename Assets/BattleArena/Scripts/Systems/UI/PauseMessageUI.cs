using TMPro;
using UnityEngine;

namespace BattleArena.Gameplay.UI
{
    public class PauseMessageUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_messageUI;
        [SerializeField]
        private string[] m_messageList;

        public void ShowRandomMessage()
        {
            m_messageUI.text = m_messageList[Random.Range(0, m_messageList.Length)];
        }
    }
}
