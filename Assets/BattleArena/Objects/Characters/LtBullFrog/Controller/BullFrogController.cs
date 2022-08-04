using BattleArena.Gameplay.Characters.Controllers;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullFrogController : CharacterBaseController
{
    SkeletonAnimation animator;
    CharacterBaseController baseController;
    private void Awake()
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
            animator.state.SetAnimation(25, "SLIDE FORWARD", true);
        }
        else if (m_translator.movementHorizontalInput > 0)
        {
            animator.state.SetAnimation(22, "SLIDE BACK", true);
        }
        else if (m_translator.movementVerticalInput < 0)
        {
            animator.state.SetAnimation(26, "SLIDE LEFT", true);
        }
        else if (m_translator.movementVerticalInput > 0)
        {
            animator.state.SetAnimation(27, "SLIDE RIGHT", true);
        }
    }
}
