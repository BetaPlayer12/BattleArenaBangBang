using BattleArena.Gameplay.Combat;
using System;
using UnityEngine;

namespace BattleArena.Gameplay.Characters
{

    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField]
        private CharacterStatData m_statData;
        private Shield m_shield;

        public event Action<Character> Died;

        public CharacterStatInfo statInfo => m_statData.info;

        Vector2 ICharacter.position => transform.position;

        public Shield shield => m_shield;

        private void OnDeath()
        {
            Died?.Invoke(this);
        }

        private void Awake()
        {
            GetComponent<Damageable>().IsDead += OnDeath;
            m_shield = GetComponent<Shield>();
        }
    }
}