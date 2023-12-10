﻿using UnityEngine;

namespace BattleArena.Gameplay.Characters
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "BattleArena/CharacterData")]
    public class CharacterData : ScriptableObject
    {
        [SerializeField]
        private string m_name;
        [SerializeField]
        private Sprite m_profilePic;
        [SerializeField]
        private GameObject m_prefab;
        [SerializeField]
        private CharacterStatData m_statData;
        [SerializeField]
        private Sprite m_winningSplashArt;

        public string characterName => m_name;
        public Sprite profilePic => m_profilePic;
        public GameObject prefab => m_prefab;
        public Sprite winningSplashArt => m_winningSplashArt;

        public CharacterStatData statData => m_statData;
    }
}