using BattleArena.Gameplay.Characters;
using UnityEngine;

namespace BattleArena.Gameplay.UI
{
    public class StatViewHandle : MonoBehaviour
    {
        [SerializeField]
        private StatsUI m_strengthUI;
        [SerializeField]
        private StatsUI m_enduranceUI;
        [SerializeField]
        private StatsUI m_agilityUI;
        [SerializeField]
        private StatsUI m_techniqueUI;

        public void DisplayStats(CharacterStatInfo stats)
        {
            m_strengthUI.DisplayValue(stats.strength);
            m_enduranceUI.DisplayValue(stats.endurance);
            m_agilityUI.DisplayValue(stats.agility);
            m_techniqueUI.DisplayValue(stats.technique);
        }
    }
}
