using BattleArena.Gameplay.Characters.Controllers.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipShieldBehavior : MonoBehaviour
{
    [SerializeField]
    private float duration; 
    private void FixedUpdate()
    {
        duration -= Time.deltaTime;
        if(duration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
