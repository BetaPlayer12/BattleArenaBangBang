using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena.Gameplay.Characters
{
    [System.Serializable]
    public struct CharacterStatInfo
    {
        private const int SMALLESTVALUE =1;
        private const int LARGESTVALUE =17;

        [SerializeField,MinValue(SMALLESTVALUE), MaxValue(LARGESTVALUE), OnValueChanged("CalculateTotal")]
        private int m_strength;
        [SerializeField, MinValue(SMALLESTVALUE), MaxValue(LARGESTVALUE), OnValueChanged("CalculateTotal")]
        private int m_endurance;
        [SerializeField, MinValue(SMALLESTVALUE), MaxValue(LARGESTVALUE), OnValueChanged("CalculateTotal")]
        private int m_agility;
        [SerializeField, MinValue(SMALLESTVALUE), MaxValue(LARGESTVALUE), OnValueChanged("CalculateTotal")]
        private int m_technique;

#if UNITY_EDITOR
        [SerializeField, ReadOnly,InfoBox("Exceeded Allocated Points", InfoMessageType.Error, visibleIfMemberName: "@m_allocatedPointsLeft < 0")]
        private int m_allocatedPointsLeft;

        private void CalculateTotal()
        {
            m_allocatedPointsLeft = 20 - m_strength - m_endurance - m_agility - m_technique;
        }
#endif

        public int strength => m_strength;
        public int endurance => m_endurance;
        public int agility => m_agility;
        public int technique => m_technique;
    }
}