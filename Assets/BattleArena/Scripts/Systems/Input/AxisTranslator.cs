using UnityEngine;
using UnityEngine.InputSystem;

namespace BattleArena.Gameplay.Inputs
{
    [System.Serializable]
    public class Vector2Translator : IInputTranslatorModule
    {
        [SerializeField]
        private Vector2 m_value;

        public Vector2 value => m_value;

        public void ExecuteLateUpdate()
        {
        }

        public void ResetValues()
        {
            m_value = Vector2.zero;
        }

        public void TranslateXInput(InputValue value)
        {
            m_value.x = value.Get<float>();
        }

        public void TranslateYInput(InputValue value)
        {
            m_value.y = value.Get<float>();
        }
    }

}