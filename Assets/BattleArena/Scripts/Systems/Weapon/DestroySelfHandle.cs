using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena
{
    public class DestroySelfHandle : MonoBehaviour
    {
        public void DestroyMyself()
        {
            Destroy(gameObject);
        }
    }
}
