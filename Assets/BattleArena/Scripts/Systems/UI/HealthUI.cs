using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay.UI
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_main;
        [SerializeField]
        private Image m_icon;
        [SerializeField, MinValue(1)]
        private int m_maxValue = 1;

        public int maxValue => m_maxValue;

        public void Show(bool isTrue)
        {
            m_main.SetActive(isTrue);
        }

        public void SetValue(int value)
        {
            if (value == 0)
            {
                m_icon.fillAmount = 0;
            }
            else
            {
                m_icon.fillAmount = value / (float)m_maxValue;
            }
            //}
        }
    }
}