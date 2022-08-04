using UnityEngine.InputSystem;

namespace BattleArena.Gameplay.Inputs
{
    [System.Serializable]
    public class ButtonTranslator : IInputTranslatorModule
    {
        private bool m_isPressed;
        private bool m_isHeld;
        private bool m_isReleased;

        public bool isPressed => m_isPressed;
        public bool isHeld => m_isHeld;
        public bool isReleased => m_isReleased;

        public void ExecuteLateUpdate()
        {
            m_isPressed = false;
            m_isReleased = false;
        }

        public void ResetValues()
        {
            m_isPressed = false;
            m_isHeld = false;
            m_isReleased = false;
        }

        public void TranslateInput(InputValue value)
        {
            var inputValue = value.Get<float>() == 1;
            if (inputValue == false)
            {
                if (m_isHeld == true)
                {
                    m_isReleased = true;
                }
            }

            m_isPressed = inputValue;
            m_isHeld = inputValue;
        }
    }

}