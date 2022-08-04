using BattleArena.Gameplay.Characters;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay.UI
{
    public class AbilityUIHandle : MonoBehaviour
    {
        [SerializeField]
        private Image m_icon;
        [SerializeField]
        private Image m_cooldownImage;
        [SerializeField]
        private TextMeshProUGUI m_cooldownTimer;

        private Ability m_toDisplay;
        private float m_cooldownDuration;

        public void Display(Ability ability)
        {
            if (m_toDisplay != null)
            {
                m_toDisplay.OnCooldownUpdate -= OnCooldownUpdate;
            }

            m_toDisplay = ability;
            m_icon.sprite = m_toDisplay.info.icon;
            m_toDisplay.OnCooldownUpdate += OnCooldownUpdate;
            m_cooldownDuration = m_toDisplay.cooldownDuration;
            m_cooldownImage.fillAmount = 0;
            m_cooldownTimer.text = "";
        }

        private void OnCooldownUpdate(Ability.AbilityCooldownInfo obj)
        {
            if (obj.isOnCooldown)
            {
                m_cooldownImage.fillAmount = obj.timeLeft / m_cooldownDuration;
                m_cooldownTimer.text = obj.timeLeft.ToString("##.#");
                m_cooldownTimer.enabled = true;
            }
            else
            {
                m_cooldownImage.fillAmount = 0;
                m_cooldownTimer.text = "";
            }
        }
    }
}