using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Characters.Controllers;
using BattleArena.Gameplay.Combat;
using BattleArena.Gameplay.Inputs;
using BattleArena.Gameplay.Systems;
using BattleArena.Gameplay.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BattleArena.Gameplay
{
    public class PlayerManager : MonoBehaviour
    {
        private class PlayerData
        {
            public CharacterData data;
            public CharacterBaseController controller;

            public PlayerData(CharacterData data,CharacterBaseController controller)
            {
                this.data = data;
   
                this.controller = controller;
            }
        }

        private static InitializationCommand m_command;
        private static InputDevice[] m_inputDevices;
        private static CharacterInitializer m_characterInitializer;
        private static Dictionary<Character, PlayerData> m_playerData;


        [SerializeField]
        private CharacterUIHandle m_player1UI;
        [SerializeField]
        private CharacterUIHandle m_player2UI;
        [SerializeField]
        private GameObject m_playerInputTemplate;

        private List<GameObject> m_instanceCache;

        public void SetPlayersToInitialize(InitializationCommand initializationCommand) => m_command = initializationCommand;

        public CharacterData GetCharacterData(Character character) => m_playerData[character].data;

        public void DestroyAllPlayerCharacters()
        {
            m_playerData.Clear();
            for (int i = m_instanceCache.Count - 1; i >= 0; i--)
            {
                Destroy(m_instanceCache[i]);
            }
        }

        public (Character p1, Character p2) CreatePlayerCharacters()
        {
            if (m_playerData.Count > 0)
            {
                DestroyAllPlayerCharacters();
            }

            var p1Input = InstantiatePlayerInput(m_playerInputTemplate, 1);
            var p1 = m_characterInitializer.CreateCharacter(m_command.player1.prefab, p1Input.GetComponent<InputTranslator>());
            m_player1UI.DisplayCharacterData(p1, m_command.player1);
            var p2Input = InstantiatePlayerInput(m_playerInputTemplate, 2);
            var p2 = m_characterInitializer.CreateCharacter(m_command.player2.prefab, p2Input.GetComponent<InputTranslator>());
            m_player2UI.DisplayCharacterData(p2, m_command.player2);

            m_playerData.Clear();
            m_playerData.Add(p1, new PlayerData(m_command.player1, p1.GetComponentInChildren<CharacterBaseController>()));
            m_playerData.Add(p2, new PlayerData(m_command.player2, p2.GetComponentInChildren<CharacterBaseController>()));
            m_instanceCache.Add(p1Input);
            m_instanceCache.Add(p1.gameObject);
            m_instanceCache.Add(p2Input);
            m_instanceCache.Add(p2.gameObject);
            return (p1, p2);
        }

        public void EnablePlayerControllers(bool isTrue)
        {
            foreach (var character in m_playerData.Keys)
            {
                m_playerData[character].controller.enabled = isTrue;
            }
        }

        private GameObject InstantiatePlayerInput(GameObject prefab, int playerIndex)
        {
            var playerInput = PlayerInput.Instantiate(prefab, controlScheme: "Keyboard&Mouse", pairWithDevices: m_inputDevices);
            playerInput.SwitchCurrentActionMap($"Player{playerIndex}");
            playerInput.gameObject.name = $"Player{playerIndex}";
            return playerInput.gameObject;
        }

        private void Awake()
        {
            m_inputDevices = new InputDevice[] { Keyboard.current, Mouse.current };
            m_characterInitializer = new CharacterInitializer();
            m_playerData = new Dictionary<Character, PlayerData>();
            m_instanceCache = new List<GameObject>();
        }
    }
}
