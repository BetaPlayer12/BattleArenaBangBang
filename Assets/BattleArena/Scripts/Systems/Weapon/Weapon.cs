using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private Transform m_reference;
        [SerializeField]
        private WeaponData m_data;
        [SerializeField]
        private string m_bulletPhysics;

        private FiringMechanism m_firingMechanism;

        public event Action<WeaponData> WeaponChanged;
        public bool needsToBeCharged => m_firingMechanism.needsToBeCharged;
        public WeaponData currentData => m_data;


        public void SetBulletPhysics(string bulletPhysics)
        {
            m_bulletPhysics = bulletPhysics;
            if (m_firingMechanism != null)
            {
                m_firingMechanism.SetPhysicsLayer(LayerMask.NameToLayer(m_bulletPhysics));
            }
        }

        public void SetData(WeaponData data)
        {
            m_data = data;
            if (m_data != null)
            {
                m_firingMechanism = m_data.GetFiringMechanism();
                m_firingMechanism.SetPhysicsLayer(LayerMask.NameToLayer(m_bulletPhysics));
            }
            WeaponChanged?.Invoke(data);
        }

        public void Fire()
        {
            if (m_firingMechanism.isOnCooldown == false)
            {
                m_firingMechanism.Fire(m_reference.position, m_reference.right);
            }
        }

        public void Charge()
        {
            if (m_firingMechanism.isOnCooldown == false)
            {
                m_firingMechanism.Charge(Time.deltaTime);
            }
        }

        private void Start()
        {
            if (m_data != null)
            {
                SetData(m_data);
            }
        }

        private void Update()
        {
            if (m_firingMechanism?.isOnCooldown ?? false)
            {
                m_firingMechanism.HandleCooldown(Time.deltaTime);
            }
        }
    }

}