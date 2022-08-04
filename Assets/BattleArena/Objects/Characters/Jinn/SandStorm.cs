using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Systems;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandStorm : Ability
{
    [SerializeField]
    private GameObject m_attackPrefab;
    [SerializeField]
    private Transform[] m_spawnPoints;
    [SerializeField]
    private SkeletonAnimation animator;

    private GameObject attack;

    protected override void OnExecution()
    {
        StartCoroutine(ExecuteRoutine());

        //foreach (Transform spawnpoint in m_spawnPoints)
        //{
        //    attack = AttackerSpawner.SpawnAttacker(m_attackPrefab, m_owner);
        //    //attack.transform.position = spawnpoint.transform.position;
        //    attack.transform.position = CombatManager.GetOpponentData(m_owner).position;
        //}
    }

    public IEnumerator ExecuteRoutine()
    {
        animator.state.SetAnimation(0, "Attack_2", false);
        animator.state.Complete += State_Complete;

        foreach (Transform spawnpoint in m_spawnPoints)
        {
            attack = AttackerSpawner.SpawnAttacker(m_attackPrefab, m_owner);
            //attack.transform.position = spawnpoint.transform.position;
            attack.transform.position = CombatManager.GetOpponentData(m_owner).position;

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void State_Complete(Spine.TrackEntry trackEntry)
    {
        animator.state.AddAnimation(0, "Move", true, 0);
    }
}
