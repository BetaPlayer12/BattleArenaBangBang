using BattleArena.Gameplay.Characters;
using System.Collections;
using UnityEngine;

public class ArenaShrinker : MonoBehaviour
{
    [SerializeField]
    private float m_delay;
    [SerializeField]
    private float m_shrinkRate;
    [SerializeField]
    private Vector3 m_smallestSize;

    private Vector3 m_originalSize;

    private float m_lerpValue;
    private float m_delayTimer;

    private void Awake()
    {
        m_originalSize = transform.localScale;
        m_delayTimer = m_delay;
        m_lerpValue = 0;
    }

    private void Update()
    {
        if (m_delayTimer <= 0)
        {
            m_lerpValue += m_shrinkRate * Time.deltaTime;
            m_lerpValue = Mathf.Clamp01(m_lerpValue);
            transform.localScale = Vector3.Lerp(m_originalSize, m_smallestSize, m_lerpValue);
        }
        else
        {
            m_delayTimer -= Time.deltaTime;
        }
    }

    public void Reset()
    {
        transform.localScale = m_originalSize;
        m_delayTimer = m_delay;
        m_lerpValue = 0;
    }
}
