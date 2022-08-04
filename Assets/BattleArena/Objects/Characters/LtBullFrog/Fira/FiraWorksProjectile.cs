using BattleArena;
using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Combat;
using BattleArena.Gameplay.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiraWorksProjectile : MonoBehaviour
{

    float timer = 0;

    [SerializeField]
    GameObject Explodes;

    [SerializeField]
    List<Transform> ports = new List<Transform>();

    [SerializeField]
    GameObject m_Explosion;

    bool hasCast;

    public Character tefe;


    public void Explode()
    {
        for (int x = 0; x < ports.Count; x++)
        {
            var spreadBomb = AttackerSpawner.SpawnAttacker(m_Explosion, tefe);
            spreadBomb.transform.position = ports[x].transform.position;
            var rightNormalize = ports[x].right;
            spreadBomb.transform.right = rightNormalize;
            spreadBomb.GetComponent<Rigidbody2D>().AddForce(rightNormalize * 10f, ForceMode2D.Impulse);
        }

    }

    private void Awake()
    {
        timer = 3f;
        hasCast = false;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 2.8 && hasCast == false)
        {
            Explode();
            Explodes.gameObject.SetActive(true);
            hasCast = true;


        }
    }
}
