using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay.UI
{
    public class CharacterUIHandle : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_characterName;
        [SerializeField]
        private Image m_icon;
        [SerializeField]
        private HealthUIHandle m_healthUI;
        [SerializeField]
        private ShieldUI m_shieldUI;
        [SerializeField]
        private WeaponUI m_weapon;

        public void DisplayCharacterData(Character character, CharacterData data)
        {
            m_characterName.text = data.characterName;
            m_icon.sprite = data.profilePic;
            m_healthUI.Display(character.GetComponentInChildren<Health>());
            m_shieldUI.Display(character.GetComponentInChildren<Shield>());
            m_weapon.Display(character.GetComponentInChildren<Weapon>());
        }
    }
}