using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena.Gameplay.Systems
{
    public class AttackerSpawner
    {
        private static int CalculateDamage(int strengthValue)
        {
            return strengthValue;
        }

        public static GameObject SpawnAttacker(GameObject toSpawn, Character owner)
        {
            var instance = Object.Instantiate(toSpawn);
            var attacker = instance.GetComponent<IAttacker>();
            if (attacker != null)
            {
                attacker.SetDamage(CalculateDamage(owner.statInfo.strength));
            }
            instance.AddComponent<TimeHandling>();
            IgnoreCollision(toSpawn, owner.gameObject);
            return instance;
        }

        public static void IgnoreCollision(GameObject object1, GameObject object2, bool isIgnored = true)
        {
            var object1Colliders = object1.GetComponentsInChildren<Collider2D>(true);
            var object2Colliders = object2.GetComponentsInChildren<Collider2D>(true);

            for (int i = 0; i < object1Colliders.Length; i++)
            {
                var collider = object1Colliders[i];
                for (int j = 0; j < object2Colliders.Length; j++)
                {
                    Physics2D.IgnoreCollision(collider, object2Colliders[j], isIgnored);
                }
            }
        }
    }

}