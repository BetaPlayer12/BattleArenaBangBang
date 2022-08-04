using UnityEngine;

namespace BattleArena.Gameplay
{
    [CreateAssetMenu(fileName = "CombatCountdownMessageData", menuName = "BattleArena/CombatCountdownMessageData")]
    public class CombatCountdownMessageData : ScriptableObject
    {
        [SerializeField]
        private string[] m_messages;

        public string GetMessage(int index) => m_messages[index];
    }
}
