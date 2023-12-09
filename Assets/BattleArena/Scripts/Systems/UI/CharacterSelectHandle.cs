using BattleArena.Gameplay.Characters;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay.UI
{
    public class CharacterSelectHandle : MonoBehaviour
    {
        [SerializeField]
        private CharacterDataList m_dataList;
        [SerializeField]
        private CharacterViewUI m_viewCharacterUI;
        [SerializeField]
        private CharacterSelectReadyButtonUI m_readyButton;
        private int m_currentIndex;
        [SerializeField]
        private Sprite m_readySprite;
        [SerializeField]
        private Sprite m_notReadySprite;
        [SerializeField]
        private Image m_backgroundImage;

        public event Action ReadinessChange;
        public bool isReady { get; private set; }

        public CharacterData GetSelectedCharacter() => m_dataList.GetData(m_currentIndex);

        public void SelectNextCharacter()
        {
            m_currentIndex = (int)Mathf.Repeat(m_currentIndex + 1, m_dataList.count);
            SelectCharacter(m_currentIndex);
            m_readyButton.DisplayIsReady(false);
            m_backgroundImage.sprite = m_notReadySprite;
            isReady = false;
            ReadinessChange?.Invoke();
        }

        public void SelectPreviousCharacter()
        {
            m_currentIndex = (int)Mathf.Repeat(m_currentIndex - 1, m_dataList.count);
            SelectCharacter(m_currentIndex);
            m_readyButton.DisplayIsReady(false);
            m_backgroundImage.sprite = m_notReadySprite;
            isReady = false;
            ReadinessChange?.Invoke();
        }

        public void ConfirmCurrentCharacter()
        {
            m_readyButton.DisplayIsReady(true);
            isReady = true;
            m_backgroundImage.sprite = m_readySprite;
            ReadinessChange?.Invoke();
        }

        private void SelectCharacter(int index)
        {
            m_viewCharacterUI.Display(m_dataList.GetData(index));
        }

        public void Reset()
        {
            m_currentIndex = 0;
            SelectCharacter(m_currentIndex);
            isReady = false;
            m_backgroundImage.sprite = m_notReadySprite;
            m_readyButton.Reset();
        }

        private void Awake()
        {
            Reset();
        }
    }
}
