using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MichaelAngelowAbility : Ability
{
    [SerializeField]
    private Transform originPoint;

    [SerializeField]
    private GameObject shieldObject;
   
    protected override void OnExecution()
    {
        StartCoroutine(ShieldRoutine());
    }

    private IEnumerator ShieldRoutine()
    {
        float time = 0;
        while (time < 0.01f)
        {
            var shield = AttackerSpawner.SpawnAttacker(shieldObject, m_owner);
            shield.transform.position = originPoint.position;
            var rightNormalize = originPoint.right;
            shield.transform.right = rightNormalize;
            time += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
