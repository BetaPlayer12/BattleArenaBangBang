using UnityEngine;

namespace BattleArena.Gameplay.Characters
{
    [CreateAssetMenu(fileName = "AbilityInfo",menuName = "BattleArena/AbilityInfo")]
    public class AbilityInfo : ScriptableObject
    {
        [SerializeField]
        private string m_abilityName;
        [SerializeField]
        private Sprite m_icon;
        [SerializeField]
        private Sprite m_reference;
        [SerializeField,TextArea(5,10)]
        private string m_description;

        public string abilityName => m_abilityName;
        public Sprite icon => m_icon;       
        public Sprite reference => m_reference;
        public string description => m_description;
    }
}