using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiraWorks : Ability
{
    [SerializeField]
    private Transform originPoint;
    private TimeHandling timeHandling;
    [SerializeField]
    private GameObject m_firaGameObject;
    [SerializeField]
    private Character m_chracter;

    public Character thisCharacter => m_chracter;
    protected override void OnExecution()
    {
        Shoot();

    }
   

    public void Shoot()
    {

        var firaProjectile = AttackerSpawner.SpawnAttacker(m_firaGameObject, m_owner);
        firaProjectile.transform.position = originPoint.position;
        var rightNormalize = originPoint.right;
        firaProjectile.transform.right = rightNormalize;
        firaProjectile.GetComponent<Rigidbody2D>().AddForce(rightNormalize * 15f, ForceMode2D.Impulse);
        firaProjectile.GetComponent<FiraWorksProjectile>().tefe = m_chracter;
    }
}
