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

        public void Display(CharacterData character)
        {
            m_profileUI.Display(character);
            //m_statView.DisplayStats(character.statData.info);
            var characterGO = character.prefab.GetComponent<Character>();
        }
    }
}
