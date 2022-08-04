using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Characters.Controllers.Modules;
using BattleArena.Gameplay.Inputs;
using UnityEngine;

namespace BattleArena.Gameplay.Characters.Controllers
{
    public abstract class CharacterBaseController : MonoBehaviour
    {
        [SerializeField]
        protected InputTranslator m_translator;

        protected Ability m_primaryAbility;
        protected Ability m_secondaryAbility;
        private CharacterMovement m_movement;
        private CharacterRotation m_rotation;

        public void SetInput(InputTranslator input)
        {
            m_translator = input;
        }
        protected void HandleMovement()
        {
            m_movement.Execute(m_translator.movementHorizontalInput, m_translator.movementVerticalInput);
        }
        protected void HandleRotation()
        {
            m_rotation.Execute(m_translator.rotationHorizontalInput, m_translator.rotationVerticalInput);
        }


        protected virtual void Start()
        {
            m_movement = GetComponent<CharacterMovement>();
            m_rotation = GetComponent<CharacterRotation>();
            var character = GetComponent<Character>();
            m_primaryAbility = character.primaryAbility;
            m_secondaryAbility = character.secondaryAbility;
        }

        protected virtual void OnEnable()
        {
            //m_translator.Reset();
        }

        protected virtual void OnDisable()
        {
            
        }

        protected virtual void FixedUpdate()
        {
            HandleMovement();
        }


        protected virtual void Update()
        {
            HandleRotation();
            if (m_primaryAbility.isOnCooldown == false && m_translator.primaryAbility.isPressed)
            {
                m_primaryAbility.Execute();
            }
            else if (m_secondaryAbility.isOnCooldown == false && m_translator.secondaryAbility.isPressed)
            {
                m_secondaryAbility.Execute();
            }
        }

        private void LateUpdate()
        {
            if (m_primaryAbility.isOnCooldown)
            {
                m_primaryAbility.HandleCooldown();
            }
            if (m_secondaryAbility.isOnCooldown)
            {
                m_secondaryAbility.HandleCooldown();
            }
        }
    }
}