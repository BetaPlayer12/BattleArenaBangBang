using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    [SerializeField]
    private float m_lifetime;

    private void Update()
    {
        m_lifetime -= Time.deltaTime;
        if (m_lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
