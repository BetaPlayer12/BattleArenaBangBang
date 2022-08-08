using UnityEngine;

namespace BattleArena
{
    public abstract class FiringMechanism
    {
        protected int m_physicsLayer;

        public abstract bool needsToBeCharged { get; }
        public abstract bool isOnCooldown { get; }

        public abstract void HandleCooldown(float delta);

        public abstract void Fire(Vector3 startPosition, Vector3 rotation);
        public abstract void Charge(float delta);

        public void SetPhysicsLayer(int layer)
        {
            m_physicsLayer = layer;
        }
    }

}