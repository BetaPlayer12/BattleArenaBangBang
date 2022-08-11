using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOut : MonoBehaviour
{
    [SerializeField]
    private float duration;

    private float currentDuration;

    // Start is called before the first frame update
    void Start()
    {
        currentDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        currentDuration -= Time.deltaTime;

        if (currentDuration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
