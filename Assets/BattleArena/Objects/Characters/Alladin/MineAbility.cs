using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineAbility : MonoBehaviour
{
    [SerializeField]
    private GameObject mine;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private float Delay = 2;
    
    void Start()
    {
        
        StartCoroutine(DelayCoroutine());
        
    }

    private void explode()
    {
        
        mine.GetComponent<Collider2D>().enabled = true;
        explosion.SetActive(false);

    }

    IEnumerator DelayCoroutine()
    {
       
        yield return new WaitForSeconds(Delay);
        explosion.SetActive(true);
        explode();

    }
    

}
