using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteAnimationHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject dynamite;
    //[SerializeField]
    //private GameObject explosion;
    //[SerializeField]
    //private SkeletonAnimation anim;
    // Start is called before the first frame update
    [SerializeField]
    private float Delay = 1;

    void Start()
    {

        StartCoroutine(DelayCoroutine());
        //anim.state.SetAnimation(0, "bomb_alone_explosion", false);
        //dynamite.GetComponent<Collider2D>().enabled = true;
        //anim.state.Complete += State_Complete;
    }

    private void explode()
    {

        dynamite.GetComponent<Collider2D>().enabled = true;


    }

    IEnumerator DelayCoroutine()
    {

        yield return new WaitForSeconds(Delay);

        explode();

    }
   
    private void State_Complete(Spine.TrackEntry trackEntry)
    {
        dynamite.GetComponent<Collider2D>().enabled = false;

    }

}
