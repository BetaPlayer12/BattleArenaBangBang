using BattleArena.Gameplay.Characters.Controllers;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeroController : CharacterBaseController
{

    SkeletonAnimation animator;
    
    void Awake()
    {
        animator = GetComponentInChildren<SkeletonAnimation>();
    }

   
    protected override void Update()
    {
        MovementAnimations();
        
        base.Update();
    }

    void MovementAnimations()
    {

        if (m_translator.movementHorizontalInput < 0)
        {
            animator.state.SetAnimation(6, "SLIDE_FORWARD", true);
        }
        else if (m_translator.movementHorizontalInput > 0)
        {
            animator.state.SetAnimation(5, "SLIDE_BACK", true);
        }
        else if (m_translator.movementVerticalInput < 0)
        {
            animator.state.SetAnimation(7, "SLIDE_LEFT", true);
        }
        else if (m_translator.movementVerticalInput > 0)
        {
            animator.state.SetAnimation(10, "SLIDE_RIGHT", true);
        }
      
    }

    void Abilities()
    {
        if (m_primaryAbility)
        {
            animator.state.SetAnimation(4, "SHOOT", true);
        }
        else if (m_secondaryAbility)
        {
            animator.state.SetAnimation(3, "SHIELD", true);
        }
       
    }
}
