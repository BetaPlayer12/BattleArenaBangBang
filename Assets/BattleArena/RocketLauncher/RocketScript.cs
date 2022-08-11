using BattleArena;
using BattleArena.Gameplay.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : Bullet
{
    [SerializeField]
    float increasingVelocity;
    [SerializeField]
    float travelDuration;
    [SerializeField]
    float secondBeforeDetonate;

    private Rigidbody2D thisMissileRbd;

    private void Start()
    {
        thisMissileRbd = GetComponent<Rigidbody2D>();

    }
    private IEnumerator Detonate( float timer)
    {
        thisMissileRbd.velocity = transform.right * 0f;
        yield return new WaitForSeconds(timer);
        Explode();
        
    }
    public void Explode()
    {   
        m_data.impactFx.GetComponent<DamageExplosion>().attacker = gameObject.GetComponent<Attacker>();
        Destroy(gameObject);
        Instantiate(m_data.impactFx, transform.position, transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    private void FixedUpdate()
    {
        thisMissileRbd.velocity = transform.right * increasingVelocity;
        travelDuration -= Time.deltaTime;
        if(travelDuration <= 0)
        {
            thisMissileRbd.velocity = Vector2.zero;
            StartCoroutine(Detonate(secondBeforeDetonate));
        }
    }

}
