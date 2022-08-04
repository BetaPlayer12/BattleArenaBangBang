using BattleArena.Gameplay.Characters;
using UnityEngine;

namespace BattleArena.Gameplay.Systems
{
    public class InitializationCommand
    {
        public InitializationCommand(CharacterData player1, CharacterData player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public CharacterData player1 { get; }
        public CharacterData player2 { get; }
    }
}
