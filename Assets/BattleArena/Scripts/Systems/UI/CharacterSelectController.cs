using BattleArena.Gameplay.UI;
using System;
using UnityEngine;

namespace BattleArena.Gameplay.Menu
{
    public class CharacterSelectController : MonoBehaviour
    {
        [SerializeField]
        private CharacterSelectHandle m_handle;
        
        [SerializeField]
        private KeyCode m_previousButtonInput;
        [SerializeField]
        private KeyCode m_nextButtonInput;
        [SerializeField]
        private KeyCode m_enterButtonInput;

        private void Update()
        {
            if (Input.GetKeyDown(m_previousButtonInput))
            {
                m_handle.SelectPreviousCharacter();
            }
            else if(Input.GetKeyDown(m_nextButtonInput))
            {
                m_handle.SelectNextCharacter();
            }
            else if (Input.GetKeyDown(m_enterButtonInput))
            {
                m_handle.ConfirmCurrentCharacter();
            }
        }
    }
}
