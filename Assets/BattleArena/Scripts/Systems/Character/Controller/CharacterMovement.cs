using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleArena.Gameplay.Characters.Controllers.Modules
{

    public class CharacterMovement : MonoBehaviour, IMovement
    {
        [SerializeField]
        private Rigidbody2D m_rigidbody;
        [SerializeField]
        private float m_speed;
        void IMovement.SetSpeed(float speed)
        {
            m_speed = speed;
        }

        public void Execute(float horizontalValue, float verticalValue)
        {
            m_rigidbody.velocity = new Vector2(m_speed * horizontalValue, m_speed * verticalValue);
        }

        public void Cancel()
        {
            m_rigidbody.velocity = Vector2.zero;
        }

    }

}