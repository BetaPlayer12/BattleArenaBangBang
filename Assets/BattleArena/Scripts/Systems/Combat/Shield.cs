using System;
using UnityEngine;

namespace BattleArena.Gameplay.Combat
{
    public class Shield : MonoBehaviour
    {
        private GameObject m_shieldVisual;
        private GameObject m_instantiatedSheildVisual;


        private bool m_isActivated;
        public bool isActivated => m_isActivated;

        public event Action<bool> ShieldActivationChange;

        public void TakeDamage(int value)
        {
            m_isActivated = false;
            ShieldActivationChange?.Invoke(m_isActivated);
            Destroy(m_instantiatedSheildVisual);
            m_instantiatedSheildVisual = null;
        }

        public void AddValue(int value)
        {
            m_isActivated = true;
            ShieldActivationChange?.Invoke(m_isActivated);
        }

        public void SetSheildVisuals(GameObject shieldVisuals)
        {
            m_shieldVisual = shieldVisuals;
            if (m_isActivated)
            {
                Destroy(m_instantiatedSheildVisual);
                m_instantiatedSheildVisual = Instantiate(m_shieldVisual, transform);
                m_instantiatedSheildVisual.transform.localPosition = Vector3.zero;
            }

        }
    }
}