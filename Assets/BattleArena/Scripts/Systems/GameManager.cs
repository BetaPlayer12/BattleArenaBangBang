using BattleArena.Gameplay.Menu;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using Doozy.Engine;
using BattleArena.Gameplay.Characters;
using System;
using BattleArena.Gameplay.UI;
using BattleArena.Gameplay.Systems;

namespace BattleArena.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerManager m_playerManager;
        [SerializeField]
        private CharacterSelectManager m_characterSelectManager;
        [SerializeField]
        private CombatManager m_combatManager;
        [SerializeField]
        private MapManager m_mapManager;
        [SerializeField]
        private CombatCountdownHandle m_combatCountdownHandle;
        [SerializeField]
        private CombatResultHandle m_combatResultHandle;
        [SerializeField]
        private GameTimer m_timer;

        [SerializeField]
        private PickupSpawnHandle[] m_pickupSpawnHandles;
        [SerializeField]
        private ArenaShrinker m_arenaShrinker;

        [SerializeField, MinValue(1)]
        private int m_combatCountdownDuration;
        private bool m_forceTimerReset;

        public void StartCombat()
        {
            RemoveAllBUllets();
            m_playerManager.SetPlayersToInitialize(m_characterSelectManager.CreateCharacterInitializationCommand());
            var instanceInfo = m_playerManager.CreatePlayerCharacters();
            m_combatManager.SetPlayers(instanceInfo.p1, instanceInfo.p2);
            m_combatManager.ResetPlayerStates();
            m_timer.ResetTime();
            m_timer.StopTime();
            m_forceTimerReset = true;
            StopAllCoroutines();
            StartCoroutine(StartCombatCountdownRoutine());
        }

        public void ResetCombat()
        {
            RemoveAllBUllets();
            m_combatManager.ResetPlayerStates();
            m_playerManager.EnablePlayerControllers(false);
            m_timer.ResetTime();
            m_timer.StopTime();
            m_forceTimerReset = true;
            StopAllCoroutines();
            StartCoroutine(StartCombatCountdownRoutine());
        }

        public void EndCombat()
        {
            m_combatManager.ClearCache();
            m_playerManager.DestroyAllPlayerCharacters();
            for (int i = 0; i < m_pickupSpawnHandles.Length; i++)
            {
                m_pickupSpawnHandles[i].enabled = false;
            }
            m_arenaShrinker.enabled = false;
        }

        public void Pause()
        {
            Time.timeScale = 0;
            m_playerManager.EnablePlayerControllers(false);
        }

        public void Resume()
        {
            Time.timeScale = 1;
            m_playerManager.EnablePlayerControllers(true);
        }

        public void ForceCountdown()
        {
            StopAllCoroutines();
            StartCoroutine(StartCombatCountdownRoutine());
        }

        private IEnumerator StartCombatCountdownRoutine()
        {
            for (int i = 0; i < m_pickupSpawnHandles.Length; i++)
            {
                var handle = m_pickupSpawnHandles[i];
                handle.Reset();
                handle.enabled = false;
            }
            m_arenaShrinker.Reset();
            m_arenaShrinker.enabled = false;
            m_playerManager.EnablePlayerControllers(false);
            yield return new WaitForSecondsRealtime(1f);
            m_combatCountdownHandle.ExecuteCountdown(m_combatCountdownDuration);
            yield return new WaitForSecondsRealtime(m_combatCountdownDuration - 0.5f);
            m_combatCountdownHandle.ForceStopExecution();
            m_playerManager.EnablePlayerControllers(true);
            GameEventMessage.SendEvent("StartTimerOver");
            for (int i = 0; i < m_pickupSpawnHandles.Length; i++)
            {
                m_pickupSpawnHandles[i].enabled = true;
            }
            m_arenaShrinker.enabled = true;
            m_timer.StartTime();
        }

        private void OnPlayerWon(Character winner)
        {
            if (winner == null)
            {
                m_combatResultHandle.Display(null, null, null, null);
            }
            else
            {
                var loser = (Character)CombatManager.GetOpponentData(winner);
                m_combatResultHandle.Display(winner, m_playerManager.GetCharacterData(winner), loser, m_playerManager.GetCharacterData(loser));
            }
            m_playerManager.EnablePlayerControllers(false);
            GameEventMessage.SendEvent("DeclareWinner");
            m_timer.StopTime();
        }

        private void OnTimerUpdate(float time)
        {
            if (m_forceTimerReset)
            {
                m_forceTimerReset = false;
            }
            else if (time <= 0)
            {
                OnPlayerWon(m_combatManager.GetWinningCharacter());
            }
        }

        private void RemoveAllBUllets()
        {
            var bullets = FindObjectsOfType<Bullet>();
            for (int i = bullets.Length - 1; i >= 0; i--)
            {
                Destroy(bullets[i].gameObject);
            }
        }

        private void Awake()
        {
            m_combatManager.PlayerWon += OnPlayerWon;
            m_timer.TimeUpdated += OnTimerUpdate;
            for (int i = 0; i < m_pickupSpawnHandles.Length; i++)
            {
                m_pickupSpawnHandles[i].enabled = false;
            }
            m_arenaShrinker.enabled = false;
        }

    }
}
