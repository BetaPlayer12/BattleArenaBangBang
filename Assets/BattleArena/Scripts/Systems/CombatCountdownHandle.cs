using Doozy.Engine.UI;
using Sirenix.OdinInspector;
using System.Collections;
using TMPro;
using UnityEngine;

namespace BattleArena.Gameplay.UI
{

    public class CombatCountdownHandle : MonoBehaviour
    {

        [SerializeField, TabGroup("Reference")]
        private UIView m_view;
        [SerializeField, TabGroup("Reference")]
        private TextMeshProUGUI m_message;

        [SerializeField, TabGroup("Messages")]
        private CombatCountdownMessageData m_normalMessages;
        [SerializeField, TabGroup("Messages")]
        private CombatCountdownMessageData[] m_forFunMessages;

        private CombatCountdownMessageData m_chosenMessage;
        private int m_messageIndex;
        private WaitForSeconds m_messageInterval;
        private bool m_hasDoneFirstMessage;

        public void ForceStopExecution()
        {
            m_view.Hide();
            StopAllCoroutines();
        }

        public void ShowNextMessage()
        {
            m_message.text = m_chosenMessage.GetMessage(m_messageIndex);
            m_messageIndex++;
        }

        public void ExecuteCountdown(float duration)
        {
            ChooseMessage();
            m_view.Hide(true);
            StopAllCoroutines();
            StartCoroutine(CountdownRoutine(duration));
        }

        private void ChooseMessage()
        {
            if (m_hasDoneFirstMessage)
            {
                m_chosenMessage = m_forFunMessages[Random.Range(0, m_forFunMessages.Length)];
            }
            else
            {
                m_chosenMessage = m_normalMessages;
            }
            m_messageIndex = 0;
        }

        private IEnumerator CountdownRoutine(float duration)
        {
            for (int i = 0; i < duration; i++)
            {
                m_view.Show();
                yield return m_messageInterval;
                m_view.Hide();
                yield return m_messageInterval;
            }
        }

        private void Awake()
        {
            m_messageInterval = new WaitForSeconds(0.5f);
        }
    }
}
