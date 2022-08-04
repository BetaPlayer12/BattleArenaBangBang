using BattleArena.Gameplay.Characters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay.UI
{
    public class AbilityViewHandle : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_nameText;
        [SerializeField]
        private TextMeshProUGUI m_descriptionText;
        [SerializeField]
        private Image m_icon;
        [SerializeField]
        private Image m_reference;

        public void Display(AbilityInfo abilityInfo)
        {
            m_nameText.text = abilityInfo.abilityName;
            m_descriptionText.text = abilityInfo.description;
            m_icon.sprite = abilityInfo.icon;
            m_reference.sprite = abilityInfo.reference;
        }
    }
}
