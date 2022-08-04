using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHandling : MonoBehaviour
{
    public float m_timer;

    // Start is called before the first frame update
    void Start()
    {
        m_timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        m_timer -= Time.deltaTime;
        if(m_timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
