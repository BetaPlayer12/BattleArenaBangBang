namespace BattleArena.Gameplay.Characters.Controllers
{
    public class CharacterController : CharacterBaseController
    {
        private Weapon m_weapon;

        protected override void Start()
        {
            base.Start();
            m_weapon = GetComponentInChildren<Weapon>();
        }

        protected override void Update()
        {
            base.Update();
            if (m_translator.weaponInput.isHeld)
            {
                if (m_weapon.needsToBeCharged)
                {
                    m_weapon.Charge();
                }
                else
                {
                    m_weapon.Fire();
                }
            }
            else if(m_translator.weaponInput.isReleased)
            {
                if (m_weapon.needsToBeCharged)
                {
                    m_weapon.Fire();
                }
            }
        }
    }
}