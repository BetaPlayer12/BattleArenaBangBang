using BattleArena.Gameplay;
using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Combat;
using BattleArena.Gameplay.Systems;
using UnityEngine;

namespace BattleArena.Nonami.ShieldWall
{
    public class ShieldWallSpawner : PickupItem
    {
        [SerializeField]
        private GameObject wall;
        [SerializeField]
        private bool m_isGlobal;
      

        protected override void Pickup(Collider2D collision)
        {

            if (m_isGlobal)
            {
                GameObject[] Players = UnityEngine.GameObject.FindObjectsOfType<GameObject>();
                for (int i = 0; i < Players.Length; ++i)
                {
                    if (Players[i].GetComponent<Character>() != null)
                    {

                        GameObject InstantiatedGameObject = Instantiate(wall);
                        InstantiatedGameObject.transform.SetParent(Players[i].transform);
                        float rotation = Players[i].transform.rotation.z;
                        if(rotation < 0)
                        {
                            InstantiatedGameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                            InstantiatedGameObject.transform.position = new Vector3(Players[i].transform.position.x - 5, Players[i].transform.position.y, Players[i].transform.position.z);
                        }
                        else
                        {
                            InstantiatedGameObject.transform.position = new Vector3(Players[i].transform.position.x + 5, Players[i].transform.position.y, Players[i].transform.position.z);
                        }
                        
                    }

                }

            }
        }
    }
}

