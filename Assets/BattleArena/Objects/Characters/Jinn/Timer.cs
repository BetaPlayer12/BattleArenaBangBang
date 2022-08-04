using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float m_timer;

    private float m_currentTimer;

    // Start is called before the first frame update
    void Start()
    {
        m_currentTimer = m_timer;   
    }

    // Update is called once per frame
    void Update()
    {
        HandleTimer();
    }

    void HandleTimer()
    {
        m_currentTimer -= Time.deltaTime;

        if(m_currentTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
