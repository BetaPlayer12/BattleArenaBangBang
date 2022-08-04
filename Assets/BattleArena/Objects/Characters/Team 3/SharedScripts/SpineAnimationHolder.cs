using Sirenix.OdinInspector;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimationHolder : MonoBehaviour
{
    [SerializeField]
    private SkeletonAnimation m_animation;
    [SerializeField]
    private Rigidbody2D m_rigidbody2D;
    [SerializeField]
    private Transform m_bodyModel;

    private bool m_isBusy;
#if UNITY_EDITOR
    //[SerializeField]
    //private SkeletonAnimation m_skeletonFAnimation;
    //[SerializeField]
    //private SkeletonAnimation m_skeletonBAnimation;

    public void InitializeField(SkeletonAnimation skeletonAnimation)
    {
        m_animation = skeletonAnimation;
        //m_skeletonFAnimation = animationF;
        //m_skeletonBAnimation = animationB;
    }
#endif
    [SerializeField, Spine.Unity.SpineAnimation(dataField = "m_skeletonFAnimation")]
    private string m_idleAnimation;
    [SerializeField, Spine.Unity.SpineAnimation(dataField = "m_skeletonFAnimation")]
    private string m_moveAnimation;
    [SerializeField, Spine.Unity.SpineAnimation(dataField = "m_skeletonFAnimation")]
    private string m_ability1LoopAnimation;
    [SerializeField, Spine.Unity.SpineAnimation(dataField = "m_skeletonBAnimation")]
    private string m_ability2LoopAnimation;
    [SerializeField, Spine.Unity.SpineAnimation(dataField = "m_skeletonBAnimation")]
    private string m_deathAnimation;

    private IEnumerator MovementRoutine()
    {
        while (true)
        {
            if (!m_isBusy)
            {
                if (m_rigidbody2D.velocity == Vector2.zero)
                {
                    if (m_animation.state.GetCurrent(0).Animation.ToString() != m_idleAnimation)
                    {
                        m_animation.state.SetAnimation(0, m_idleAnimation, true);
                    }
                }
                else
                {
                    if (m_rigidbody2D.velocity != Vector2.zero)
                    {
                        Vector2 v = m_rigidbody2D.velocity;
                        var angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    }
                    //var horizontalAxis = Input.GetAxisRaw("Horizontal");
                    //var verticalAxis = Input.GetAxisRaw("Vertical");
                    //m_bodyModel.rotation = Quaternion.Euler(0, 0, ChooseRotation(horizontalAxis, verticalAxis));
                    if (m_animation.state.GetCurrent(0).Animation.ToString() != m_moveAnimation)
                    {
                        m_animation.state.SetAnimation(0, m_moveAnimation, true);
                    }
                }
            }
            yield return null;
        }
    }

    public void IsBusy(bool busy)
    {
        m_isBusy = busy;
    }

    public bool CanDoAction()
    {
        return !m_isBusy;
    }

    public string IdleAnimation()
    {
        return m_idleAnimation;
    }

    public string Ability1LoopAnimation()
    {
        return m_ability1LoopAnimation;
    }

    public string Ability2LoopAnimation()
    {
        return m_ability2LoopAnimation;
    }

    public string DeathAnimation()
    {
        return m_deathAnimation;
    }

    private float ChooseRotation(float h, float v)
    {
        float direction = 0;
        if (h == 1 && v == 0)
        {
            direction = 90;
        }
        else if (h == 0 && v == 1)
        {
            direction = 180;
        }
        else if (h == 1 && v == 1)
        {
            direction = 135;
        }
        else if (h == -1 && v == 0)
        {
            direction = 270;
        }
        else if (h == 0 && v == -1)
        {
            direction = 0;
        }
        else if (h == -1 && v == -1)
        {
            direction = 315;
        }
        else if (h == 1 && v == -1)
        {
            direction = 45;
        }
        else if (h == -1 && v == 1)
        {
            direction = 225;
        }
        return direction;
    }

    private void Start()
    {
        if (m_idleAnimation != "None")
        {
            m_animation.state.SetAnimation(0, m_idleAnimation, true);
        }
        StartCoroutine(MovementRoutine());
        transform.rotation = Quaternion.Euler(0, 0, 90);
        //transform.rotation = Quaternion.identity;
    }

}
