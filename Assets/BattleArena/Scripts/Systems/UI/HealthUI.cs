using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay.UI
{
    public class HealthUI : MonoBehaviour
    {
        [System.Serializable]
        private class VersionInfo
        {
            [SerializeField]
            private Sprite m_icon;
            [SerializeField]
            private Color m_color = Color.white;

            public Sprite icon => m_icon;
            public Color color => m_color;
        }

        [SerializeField]
        private GameObject m_main;
        [SerializeField]
        private Image m_icon;
        [SerializeField]
        private VersionInfo m_okVersion;
        [SerializeField]
        private VersionInfo m_notOKVersion;
        [SerializeField, MinValue(1)]
        private int m_maxValue = 1;

        public int maxValue => m_maxValue;

        public void Show(bool isTrue)
        {
            m_main.SetActive(isTrue);
        }

        public void UseOKVersion()
        {
            UseVersion(m_okVersion);
        }

        public void UseNotOKVersion()
        {
            UseVersion(m_notOKVersion);
        }

        public void SetValue(int value)
        {
            //if (value == 0)
            //{
            //    UseNotOKVersion();
            //    m_icon.fillAmount = 1;
            //}
            //else
            //{
            UseOKVersion();
            if(value == 0)
            {
                m_icon.fillAmount = 0;
            }
            else
            {
                m_icon.fillAmount = value/(float)m_maxValue;
            }
            //}
        }

        private void UseVersion(VersionInfo versionInfo)
        {
            m_icon.sprite = versionInfo.icon;
            m_icon.color = versionInfo.color;
        }
    }
}