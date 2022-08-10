using BattleArena.Gameplay.Combat;
using UnityEngine;

namespace BattleArena.Gameplay.Characters
{
    public interface ICharacter
    {
        Vector2 position { get; }
        Shield shield { get; }
    }
}