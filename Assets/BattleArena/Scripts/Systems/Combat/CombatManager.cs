using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena.Gameplay.Systems
{
    public class CombatManager : MonoBehaviour
    {
        private class CharacterCombatData
        {
            public ICharacter opponent;
            public PlayerStartInfo startInfo;

            public CharacterCombatData(ICharacter opponent, PlayerStartInfo startInfo)
            {
                this.opponent = opponent;
                this.startInfo = startInfo;
            }
        }

        private struct PlayerStartInfo
        {
            public Vector3 startPosition;
            public Quaternion startRotation;

            public PlayerStartInfo(Vector3 startPosition, Quaternion startRotation)
            {
                this.startPosition = startPosition;
                this.startRotation = startRotation;
            }
        }

        public static void ResolveCombat(Attacker attacker, Damageable target)
        {
            target.TakeDamage(attacker.damage);
        }
        public static ICharacter GetOpponentData(Character player)
        {
            return m_playerData[player].opponent;
        }

        private static Dictionary<Character, CharacterCombatData> m_playerData;

        private PlayerStartInfo m_player1StartInfo;
        private PlayerStartInfo m_player2StartInfo;
        public event Action<Character> PlayerWon;

        public Character GetWinningCharacter()
        {
            foreach (var character in m_playerData.Keys)
            {
                var charHealth = character.GetComponent<Health>().currentValue;
                var opponent = (Character)m_playerData[character].opponent;
                var oppHealth = opponent.GetComponent<Health>().currentValue;
                if (charHealth > oppHealth)
                {
                    return character;
                }
                else if (charHealth < oppHealth)
                {
                    return opponent;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        public void SetPlayers(Character player1, Character player2)
        {
            if (m_playerData.Count > 0)
            {
                ClearCache();
            }
            m_playerData.Add(player1, new CharacterCombatData(player2, m_player1StartInfo));
            m_playerData.Add(player2, new CharacterCombatData(player1, m_player2StartInfo));
            player1.Died += OnPlayerDeath;
            player2.Died += OnPlayerDeath;
        }

        public void ResetPlayerStates()
        {
            foreach (var character in m_playerData.Keys)
            {
                var startInfo = m_playerData[character].startInfo;
                character.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                character.transform.position = startInfo.startPosition;
                character.transform.rotation = startInfo.startRotation;
                var health = character.GetComponentInChildren<IHealth>();
                health.Reset();
            }
        }

        public void ClearCache()
        {
            foreach (var character in m_playerData.Keys)
            {
                character.Died -= OnPlayerDeath;
            }
            m_playerData.Clear();
        }

        private void OnPlayerDeath(Character obj)
        {
            PlayerWon?.Invoke(obj);
        }

        private void Awake()
        {
            m_playerData = new Dictionary<Character, CharacterCombatData>();
            m_player1StartInfo = new PlayerStartInfo(new Vector3(-30, 0, 0), Quaternion.Euler(0, 0, 0));
            m_player2StartInfo = new PlayerStartInfo(new Vector3(30, 0, 0), Quaternion.Euler(0, 0, 180));
        }
    }

}