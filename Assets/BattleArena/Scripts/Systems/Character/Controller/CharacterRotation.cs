using UnityEngine;

namespace BattleArena.Gameplay.Characters.Controllers.Modules
{
    public class CharacterRotation : MonoBehaviour
    {
        [SerializeField]
        private Transform m_character;

        private Vector2 m_rotationInput;

        public void Execute(float horizontalValue, float verticalValue)
        {
            var newInput = new Vector2(horizontalValue, verticalValue);
            if (newInput != Vector2.zero && m_rotationInput != newInput)
            {
                m_character.right = newInput;
                m_rotationInput = newInput;
            }
        }

        public void Cancel()
        {
        }

    }

}