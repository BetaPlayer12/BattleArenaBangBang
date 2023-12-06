using Sirenix.OdinInspector;
using UnityEngine;

namespace BattleArena
{
    [CreateAssetMenu(fileName = "WeaponData",menuName ="BattleArenaBangBang/Weapons/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField]
        private string m_name;
        [SerializeField]
        private Sprite m_icon;
        [SerializeField]
        private WeaponFireType m_weaponFireType;
        [SerializeField, ShowIf("@m_weaponFireType==WeaponFireType.Pew"),HideLabel]
        private PewMechanismData m_pewMechanism;

        public string name => m_name;
        public Sprite icon => m_icon;

        public FiringMechanism GetFiringMechanism()
        {
            switch (m_weaponFireType)
            {
                case WeaponFireType.Pew:
                    return new PewMechanism(m_pewMechanism);
            }

            return null;
        }
    }

}