using BattleArena.Gameplay.Characters;
using UnityEngine;

namespace BattleArena.Gameplay.UI
{
    public class CharacterViewUI : MonoBehaviour
    {
        [SerializeField]
        private ProfileUI m_profileUI;        
        [SerializeField]
        private StatViewHandle m_statView;
        [SerializeField]
        private AbilityViewHandle m_primaryAbilityView;
        [SerializeField]
        private AbilityViewHandle m_secondaryAbilityView;

        public void Display(CharacterData character)
        {
            m_profileUI.Display(character);
            m_statView.DisplayStats(character.statData.info);
            var characterGO = character.prefab.GetComponent<Character>();
            m_primaryAbilityView.Display(characterGO.primaryAbility.info);
            m_secondaryAbilityView.Display(characterGO.secondaryAbility.info);
        }
    }
}
