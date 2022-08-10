using BattleArena;
using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricFrisbeeBullet : Bullet
{
    [SerializeField]
    private int m_maxBounceCount;
    private int m_currentBounceCount;

    protected override void MoveBullet()
    {
        var velocity = m_rigidbody.velocity;
        if (velocity.magnitude < m_speed)
        {
            base.MoveBullet();
        }
    }

    protected override void OnCollision(Collider2D collision)
    {
        if (m_data.impactFx)
        {
            var impact = Instantiate(m_data.impactFx, transform.position, transform.rotation);
            var attacker = GetComponent<Attacker>();
            impact.GetComponent<IAttacker>().SetDamage(attacker.damage);
            impact.layer = gameObject.layer;
            impact.GetComponentInChildren<Collider2D>().gameObject.layer = gameObject.layer;
            impact.GetComponent<Rigidbody2D>().WakeUp();
        }
        m_currentBounceCount++;
        if (m_currentBounceCount >= m_maxBounceCount)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        base.MoveBullet();
    }
}
