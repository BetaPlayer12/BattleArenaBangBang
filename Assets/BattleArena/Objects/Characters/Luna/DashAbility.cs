using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Characters.Controllers;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena.Tests
{
    public class DashAbility : Ability
    {
        [SerializeField]
        private GameObject character;
        private Rigidbody2D temp;
        private float forwardSpeed = 30;
        [SerializeField]
        private float Delay = 0.5f;
        [SerializeField]
        private SkeletonAnimation anim;


        // Start is called before the first frame update
        protected override void OnExecution()
        {
            temp = character.GetComponent<Rigidbody2D>();
            anim.state.SetAnimation(0, "dash animation", false);
            anim.state.Complete += State_Complete;
            StartCoroutine(DelayCoroutine());

           

        }

        IEnumerator DelayCoroutine()
        {
            var controller = GetComponentInParent<CharacterBaseController>();
            controller.enabled = false;
            temp.velocity = Vector2.zero;
            temp.velocity = Vector2.right * forwardSpeed;
            yield return new WaitForSeconds(Delay);
            controller.enabled = true;
            temp.velocity = Vector2.zero;

        }
        private void State_Complete(Spine.TrackEntry trackEntry)
        {
            anim.state.AddAnimation(0, "walk cycle", true, 0);

        }
    }
}
