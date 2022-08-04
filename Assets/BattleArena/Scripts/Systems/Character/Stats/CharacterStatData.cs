using Sirenix.OdinInspector;
using UnityEngine;

namespace BattleArena.Gameplay.Characters
{
    [CreateAssetMenu(fileName = "CharacterStatData", menuName = "BattleArena/CharacterStatData")]
    public class CharacterStatData : ScriptableObject
    {
        [SerializeField,HideLabel]
        private CharacterStatInfo m_info;

        public CharacterStatInfo info => m_info;
    }
}