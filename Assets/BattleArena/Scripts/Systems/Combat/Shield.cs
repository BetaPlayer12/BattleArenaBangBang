using System;
using UnityEngine;

namespace BattleArena.Gameplay.Combat
{
    public class Shield : MonoBehaviour
    {

        private bool m_isActivated;
        public bool isActivated => m_isActivated ;

        public event Action<bool> ShieldActivationChange;

        public void TakeDamage(int value)
        {
            m_isActivated = false;
            ShieldActivationChange?.Invoke(m_isActivated);
        }

        public void AddValue(int value)
        {
            m_isActivated = true;
            ShieldActivationChange?.Invoke(m_isActivated);
        }
    }
}