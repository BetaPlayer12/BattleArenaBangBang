using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Systems;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBlast : Ability
{
    [SerializeField]
    private GameObject m_projectile;
    [SerializeField]
    private Transform[] m_spawnPositions;
    [SerializeField]
    private int m_waves;
    [SerializeField]
    private SkeletonAnimation animator;

    protected override void OnExecution()
    {
        animator.state.SetAnimation(0, "Attack_1", true);
        StartCoroutine(ExecuteRoutine());

        //foreach (Transform test in m_spawnPositions)
        //{
        //    var projectile = AttackerSpawner.SpawnAttacker(m_projectile, m_owner);
        //    projectile.transform.position = test.position;
        //    var rightNormalize = test.right;
        //    projectile.transform.right = rightNormalize;
        //    projectile.GetComponent<Rigidbody2D>().AddRelativeForce(rightNormalize * 50f, ForceMode2D.Impulse);
        //}
    }

    public IEnumerator ExecuteRoutine()
    {
        for (int i = 0; i < m_waves; i++)
        {
            foreach (Transform test in m_spawnPositions)
            {
                var projectile = AttackerSpawner.SpawnAttacker(m_projectile, m_owner);
                projectile.transform.position = test.position;
                var rightNormalize = test.right;
                projectile.transform.right = rightNormalize;
                projectile.GetComponent<Rigidbody2D>().AddRelativeForce(rightNormalize * 50f, ForceMode2D.Impulse);                
            }

            yield return new WaitForSeconds(1f);
        }

        animator.state.AddAnimation(0, "move", true, 0);
    }
}
