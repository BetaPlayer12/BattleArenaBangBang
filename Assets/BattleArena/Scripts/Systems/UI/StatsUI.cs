using BattleArena.Gameplay.Systems;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay.UI
{
    public class StatsUI : MonoBehaviour
    {
        [SerializeField]
        private Image m_fill;
        [SerializeField]
        private TextMeshProUGUI m_statText;
        [SerializeField, OnValueChanged("OnStatNameChange")]
        private string m_statName;

        public void DisplayValue(int value) => m_fill.fillAmount = (float)value / CharacterInitializer.STAT_MAXVALUE;

        private void OnStatNameChange()
        {
            m_statText.text = $"{m_statName}:";
            gameObject.name = $"{m_statName}StatPanel";
        }
    }
}
