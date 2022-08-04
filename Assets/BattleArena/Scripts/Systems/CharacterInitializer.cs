using BattleArena.Gameplay.Characters;
using BattleArena.Gameplay.Characters.Controllers;
using BattleArena.Gameplay.Characters.Controllers.Modules;
using BattleArena.Gameplay.Combat;
using BattleArena.Gameplay.Inputs;
using UnityEngine;

namespace BattleArena.Gameplay.Systems
{
    public class CharacterInitializer
    {
        public const int STAT_MAXVALUE = 17;
        private const float COOLDOWN_MAXVALUE = 7f;
        private const float COOLDOWN_MINVALUE = 0.5f;

        public static float CalculateCooldown(int techniqueValue)
        {
            var statsLerp = (float)techniqueValue / 14f;
            if (techniqueValue == 1)
            {
                statsLerp = 0;
            }
            return Mathf.Lerp(COOLDOWN_MAXVALUE, COOLDOWN_MINVALUE, statsLerp);
        }

        public static int CalculatePower(int strengthValue)
        {
            return strengthValue;
        }

        public static int CalculateHealth(int enduranceValue)
        {
            return enduranceValue * 2;
        }

        public static float CalculateSpeed(int agilityValue)
        {
            return agilityValue * 5;
        }

        public Character CreateCharacter(GameObject prefab, InputTranslator input)
        {
            var instance = Object.Instantiate(prefab);
            instance.GetComponent<CharacterBaseController>().SetInput(input);
            var character = instance.GetComponent<Character>();
            var statInfo = character.statInfo;
            instance.GetComponent<IMovement>().SetSpeed(CalculateSpeed(statInfo.agility));
            InitializeAbilities(character.primaryAbility, statInfo);
            InitializeAbilities(character.secondaryAbility, statInfo);
            var health = instance.GetComponentInChildren<Health>();
            InitializeHealth(health, statInfo);
            return character;
        }

        private void InitializeAbilities(IAbility ability, CharacterStatInfo statInfo)
        {
            ability.SetCooldownDuration(CalculateCooldown(statInfo.technique));
            ability.SetPower(CalculatePower(statInfo.strength));
        }

        private void InitializeHealth(IHealth health, CharacterStatInfo statInfo)
        {
            var healthValue = CalculateHealth(statInfo.endurance);
            health.SetMax(healthValue);
            health.SetCurrent(healthValue);
        }
    }
}
