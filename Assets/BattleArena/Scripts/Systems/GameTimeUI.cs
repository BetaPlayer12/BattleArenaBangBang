using TMPro;
using UnityEngine;

namespace BattleArena.Gameplay
{
    public class GameTimeUI : MonoBehaviour
    {
        [SerializeField]
        private GameTimer m_timer;
        [SerializeField]
        private TextMeshProUGUI m_ui;

        private void Awake()
        {
            m_timer.TimeUpdated += OnTimeUpdate;
        }

        private void OnTimeUpdate(float val)
        {
            m_ui.text = $"{Mathf.FloorToInt(val)}";
        }
    }
}