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

        }

        private void LateUpdate()
        {

        }
    }
}