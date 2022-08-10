using BattleArena;
using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShield : MonoBehaviour
{
    [SerializeField]
    private float shieldDuration;

    private float currentDurationTimer;
    private float healValue;

    // Start is called before the first frame update
    void Start()
    {
        currentDurationTimer = shieldDuration;
        healValue = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            gameObject.GetComponentInParent<Damageable>().Heal(10);
            healValue += 5;
            Destroy(collision.gameObject);
        }
    }
}
