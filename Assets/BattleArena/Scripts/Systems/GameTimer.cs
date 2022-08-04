using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena.Gameplay
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField]
        private float m_maxTime;

        private float m_currentTime;

        public event Action<float> TimeUpdated;

        public void ResetTime()
        {
            m_currentTime = m_maxTime;
            TimeUpdated?.Invoke(m_currentTime);
        }

        public void StartTime()
        {
            enabled = true;
        }

        public void StopTime()
        {
            enabled = false;
        }

        private void Start()
        {
            ResetTime();
            StopTime();
        }

        void Update()
        {
            m_currentTime -= Time.deltaTime;
            if(m_currentTime < 0)
            {
                m_currentTime = 0;
                enabled = false;
            }
            TimeUpdated?.Invoke(m_currentTime);

        }
    }
}