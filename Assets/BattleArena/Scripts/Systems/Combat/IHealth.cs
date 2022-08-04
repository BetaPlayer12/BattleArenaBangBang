namespace BattleArena.Gameplay.Combat
{
    public interface IHealth
    {
        void Add(int value);
        void SetMax(int maxValue);
        void SetCurrent(int value);
        void Reset();
    }
}