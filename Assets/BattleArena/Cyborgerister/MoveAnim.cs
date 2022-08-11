using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnim : MonoBehaviour
{
    public SkeletonAnimation m_animation;
    public Rigidbody2D m_rbd;
    void Update()
    {
        if(m_rbd.velocity == Vector2.zero)
        {
            if (m_animation.state.GetCurrent(0).Animation.ToString() != "idle")
            {
                m_animation.AnimationState.SetAnimation(0, "idle", true);
            }
               
        }
        else
        {
            if(m_animation.state.GetCurrent(0).Animation.ToString() != "Move")
            {
                m_animation.AnimationState.SetAnimation(0, "Move", true);
            }
            
        }
    }
}
