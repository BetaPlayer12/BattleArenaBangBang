using BattleArena.Gameplay.Combat;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena.Gameplay.UI
{
    public class HealthUIHandle : MonoBehaviour
    {
        private Health m_toDisplay;
        private List<HealthUI> m_uis;
        private int m_maxHealth;

        public void Display(Health health)
        {
            if (m_toDisplay != null)
            {
                m_toDisplay.OnValueChanged -= OnHealthValueChange;
            }

            m_toDisplay = health;
            var currentHealth = m_toDisplay.maxValue;
            m_maxHealth = m_toDisplay.maxValue;
            for (int i = 0; i < m_uis.Count; i++)
            {
                var ui = m_uis[i];
                var showUI = currentHealth > 0;
                ui.Show(showUI);
                if (showUI)
                {
                    var value = Mathf.Min(currentHealth, ui.maxValue);
                    ui.SetValue(value);
                }
                currentHealth -= ui.maxValue;
            }

            m_toDisplay.OnValueChanged += OnHealthValueChange;
        }

        private void OnHealthValueChange(int currentHealth)
        {
            for (int i = 0; i < m_uis.Count; i++)
            {
                var ui = m_uis[i];
                var value = Mathf.Min(currentHealth, ui.maxValue);
                ui.SetValue(value);
                currentHealth -= ui.maxValue;
                if (currentHealth < 0)
                {
                    currentHealth = 0;
                }
            }
        }

        private void Awake()
        {
            m_uis = new List<HealthUI>(GetComponentsInChildren<HealthUI>());
        }
    }
}