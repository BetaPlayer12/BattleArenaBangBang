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
        [SerializeField]
        private ButtonTranslator m_weaponInput;

        private IInputTranslatorModule[] m_modulesArray;

        public float movementHorizontalInput => m_movementAxisInput.value.x;
        public float movementVerticalInput => m_movementAxisInput.value.y;
        public float rotationHorizontalInput => m_rotationAxisInput.value.x;
        public float rotationVerticalInput => m_rotationAxisInput.value.y;
        public ButtonTranslator weaponInput => m_weaponInput;

        private void OnMove(InputValue inputValue)
        {
            m_movementAxisInput.TranslateInput(inputValue);
        }

        private void OnRotate(InputValue inputValue)
        {
            m_rotationAxisInput.TranslateInput(inputValue);
        }

        private void OnWeaponFire(InputValue inputValue)
        {
            m_weaponInput.TranslateInput(inputValue);
        }

        private void Awake()
        {
            m_movementAxisInput = new Vector2Translator();
            m_rotationAxisInput = new Vector2Translator();
            m_weaponInput = new ButtonTranslator();
            m_modulesArray = new IInputTranslatorModule[] { m_movementAxisInput, m_rotationAxisInput, m_weaponInput };
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