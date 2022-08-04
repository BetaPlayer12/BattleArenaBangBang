using UnityEngine;
using UnityEngine.InputSystem;

namespace BattleArena.Gameplay.Inputs
{
    [System.Serializable]
    public class Vector2Translator : IInputTranslatorModule
    {
        private Vector2 m_value;

        public Vector2 value => m_value;

        public void ExecuteLateUpdate()
        {
        }

        public void ResetValues()
        {
            m_value = Vector2.zero;
        }

        public void TranslateInput(InputValue value)
        {
            m_value = value.Get<Vector2>();

            //m_value.x = ClampValue(m_value.x);
            //m_value.y = ClampValue(m_value.y);

            float ClampValue(float axisValue)
            {
                if (axisValue < 1 && axisValue > -1)
                {
                    axisValue = 0;
                }
                return axisValue;
            }
        }
    }

}