using UnityEngine;

namespace BattleArena.Gameplay.Characters
{
    [CreateAssetMenu(fileName = "CharacterDataList", menuName = "BattleArena/CharacterDataList")]
    public class CharacterDataList : ScriptableObject
    {
        [SerializeField]
        private CharacterData[] m_characterDatas;

        public int count => m_characterDatas.Length;

        public CharacterData GetData(int index) => m_characterDatas[index];
    }
}