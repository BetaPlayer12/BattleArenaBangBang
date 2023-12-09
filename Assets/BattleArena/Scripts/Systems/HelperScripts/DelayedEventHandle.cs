using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BattleArena
{
    public class DelayedEventHandle : MonoBehaviour
    {
        [SerializeField]
        private float m_delayInSeconds;
        [SerializeField]
        private UnityEvent m_event;

        public void InvokeEvent()
        {
            StartCoroutine(Countdown(m_delayInSeconds));
        }

        private IEnumerator Countdown(float delay)
        {
            yield return new WaitForSeconds(delay);
            m_event.Invoke();
        }
    }

}
