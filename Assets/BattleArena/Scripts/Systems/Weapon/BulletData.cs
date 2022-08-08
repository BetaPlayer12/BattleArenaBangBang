using UnityEngine;

namespace BattleArena
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "BattleArenaBangBang/Weapons/Bullet Data")]
    public class BulletData : ScriptableObject
    {
        [SerializeField]
        private GameObject m_impactFx;
        public GameObject impactFx => m_impactFx;
    }

}