using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena.Nonami.FlameThrower
{
    public class ScorchedEarth : MonoBehaviour
    {
        public void Start()
        {
            this.gameObject.GetComponent<IAttacker>().SetDamage(5);
            StartCoroutine(ScorchDeathCoroutine());
        }
        IEnumerator ScorchDeathCoroutine()
        {
            yield return new WaitForSeconds(3);
            Object.Destroy(this.gameObject);
        }
    }
}
