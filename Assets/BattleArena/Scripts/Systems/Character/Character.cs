using BattleArena.Gameplay.Combat;
using System;
using UnityEngine;

namespace BattleArena.Gameplay.Characters
{

    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField]
        private CharacterStatData m_statData;
        [SerializeField]
        private Ability m_primaryAbility;
        [SerializeField]
        private Ability m_secondaryAbility;

        public event Action<Character> Died;

        public CharacterStatInfo statInfo => m_statData.info;
        public Ability primaryAbility => m_primaryAbility;
        public Ability secondaryAbility => m_secondaryAbility;

        Vector2 ICharacter.position => transform.position;
        private void OnDeath()
        {
            Died?.Invoke(this);
        }

        private void Awake()
        {
            GetComponent<Damageable>().IsDead += OnDeath;
        }

    }
}