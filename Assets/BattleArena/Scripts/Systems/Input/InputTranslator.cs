using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BattleArena.Gameplay.Inputs
{
    public class InputTranslator : MonoBehaviour
    {
        private Vector2Translator m_movementAxisInput;
        private Vector2Translator m_rotationAxisInput;

        private ButtonTranslator m_primaryAbility;
        private ButtonTranslator m_secondaryAbility;

        private IInputTranslatorModule[] m_modulesArray;

        public float movementHorizontalInput => m_movementAxisInput.value.x;
        public float movementVerticalInput => m_movementAxisInput.value.y;
        public float rotationHorizontalInput => m_rotationAxisInput.value.x;
        public float rotationVerticalInput => m_rotationAxisInput.value.y;
        public ButtonTranslator primaryAbility => m_primaryAbility;
        public ButtonTranslator secondaryAbility => m_secondaryAbility;

        private void OnMove(InputValue inputValue)
        {
            m_movementAxisInput.TranslateInput(inputValue);
        }

        private void OnRotate(InputValue inputValue)
        {
            m_rotationAxisInput.TranslateInput(inputValue);
        }

        private void OnPrimaryAbility(InputValue inputValue)
        {
            m_primaryAbility.TranslateInput(inputValue);
        }

        private void OnSecondaryAbility(InputValue inputValue)
        {
            m_secondaryAbility.TranslateInput(inputValue);
        }

        private void Awake()
        {
            m_movementAxisInput = new Vector2Translator();
            m_rotationAxisInput = new Vector2Translator();
            m_primaryAbility = new ButtonTranslator();
            m_secondaryAbility = new ButtonTranslator();
            m_modulesArray = new IInputTranslatorModule[] { m_movementAxisInput, m_rotationAxisInput, m_primaryAbility, m_secondaryAbility };
        }

        private void LateUpdate()
        {
            for (int i = 0; i < m_modulesArray.Length; i++)
            {
                m_modulesArray[i].ExecuteLateUpdate();
            }
        }

        public void Reset()
        {
            for (int i = 0; i < m_modulesArray.Length; i++)
            {
                m_modulesArray[i].ResetValues();
            }
        }
    }
}