using UnityEngine.InputSystem;

namespace BattleArena.Gameplay.Inputs
{
    public interface IInputTranslatorModule
    {
        void ResetValues();
        void ExecuteLateUpdate();

        void TranslateInput(InputValue value);
    }
}