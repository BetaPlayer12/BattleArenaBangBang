using BattleArena.Gameplay.Combat;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay.UI
{
    public class ShieldUI : MonoBehaviour
    {
        [SerializeField]
        private Image m_bar;
        [SerializeField]
        private Color m_shieldedColor;
        [SerializeField]
        private Color m_nonShieldedColor;

        private Shield m_currentShield;

        public void Display(Shield shield)
        {
            if(m_currentShield != null)
            {
                m_currentShield.ShieldActivationChange -= OnShieldActivationChange;
            }

            ChangeUI(shield.isActivated);
            m_currentShield = shield;
            m_currentShield.ShieldActivationChange += OnShieldActivationChange;
        }

        private void OnShieldActivationChange(bool obj)
        {
            ChangeUI(obj);
        }

        private void ChangeUI(bool hasShield)
        {
            if (hasShield)
            {
                m_bar.color = m_shieldedColor;
            }
            else
            {
                m_bar.color = m_nonShieldedColor;
            }
        }
    }
}