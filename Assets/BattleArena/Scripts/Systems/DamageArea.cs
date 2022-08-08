using BattleArena.Gameplay.Combat;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField]
    private float m_damagePerSecond;

    private List<Damageable> m_toDamage;
    private float m_damageTimer;

    private void Awake()
    {
        m_toDamage = new List<Damageable>();
    }

    private void Update()
    {
        if (m_damageTimer <= 0)
        {
            for (int i = m_toDamage.Count - 1; i >= 0; i--)
            {
                m_toDamage[i].TakeDamage(1);
            }
            m_damageTimer = 1f / m_damagePerSecond;
        }
        else
        {
            m_damageTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damageable = collision.GetComponentInChildren<Damageable>();
        if (damageable != null)
        {
            m_toDamage.Add(damageable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var damageable = collision.GetComponentInChildren<Damageable>();
        if (damageable != null)
        {
            m_toDamage.Remove(damageable);
        }
    }
}
