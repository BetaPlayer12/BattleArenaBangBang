using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay.UI
{
    public class WeaponUI : MonoBehaviour
    {
        [SerializeField]
        private Image m_icon;
        [SerializeField]
        private TextMeshProUGUI m_label;

        public void Display(Weapon weapon)
        {
            weapon.WeaponChanged += OnWeaponChanged;
            OnWeaponChanged(weapon.currentData);
        }

        private void OnWeaponChanged(WeaponData obj)
        {
            if (obj)
            {
                m_icon.sprite = obj.icon;
                m_label.text = obj.name;
            }
            else
            {
                m_icon.sprite = null;
                m_label.text = "Nothing";
            }
        }
    }
}