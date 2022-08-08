using UnityEngine;

namespace BattleArena
{
    public class ChargeMechanismData : ScriptableObject
    {
        [SerializeField]
        private float rayLength;
    }

    public class ChargeMechanism : FiringMechanism
    {
        public override bool needsToBeCharged => true;

        public override bool isOnCooldown => throw new System.NotImplementedException();

        public override void Charge(float delta)
        {
            throw new System.NotImplementedException();
        }

        public override void Fire(Vector3 startPosition, Vector3 rotation)
        {
            throw new System.NotImplementedException();
        }

        public override void HandleCooldown(float delta)
        {
            throw new System.NotImplementedException();
        }
    }

}