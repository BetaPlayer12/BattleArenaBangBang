using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena.Nonami.ShieldWall
{
    public class ShieldWall : MonoBehaviour
    {
        public void Start()
        {
            StartCoroutine(WallDeathCoroutine());
        }
        IEnumerator WallDeathCoroutine()
        {
            yield return new WaitForSeconds(5);
            Object.Destroy(this.gameObject);
        }
    }
}
