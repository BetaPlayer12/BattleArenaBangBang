using BattleArena.Gameplay.Characters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.Gameplay.UI
{
    public class ProfileUI : MonoBehaviour
    {
        [SerializeField]
        private Image m_profileImage;
        [SerializeField]
        private TextMeshProUGUI m_nameText;

        public void Display(CharacterData characterData)
        {
            m_profileImage.sprite = characterData.profilePic;
            m_nameText.text = characterData.characterName;
        }
    }
}
