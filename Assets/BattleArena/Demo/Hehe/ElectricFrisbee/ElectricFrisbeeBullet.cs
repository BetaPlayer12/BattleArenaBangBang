using BattleArena;
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
    }

    protected override void OnCollision(Collider2D collision)
    {
        if (m_data.impactFx)
        {
            Instantiate(m_data.impactFx, transform.position, transform.rotation);
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
