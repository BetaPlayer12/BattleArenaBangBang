using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Combat;
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
        private AbilityUIHandle m_primaryAbilityUI;
        [SerializeField]
        private AbilityUIHandle m_secondayAbilityUI;

        public void DisplayCharacterData(Character character, CharacterData data)
        {
            m_characterName.text = data.characterName;
            m_icon.sprite = data.profilePic;
            m_healthUI.Display(character.GetComponentInChildren<Health>());
            m_primaryAbilityUI.Display(character.primaryAbility);
            m_secondayAbilityUI.Display(character.secondaryAbility);
        }
    }
}