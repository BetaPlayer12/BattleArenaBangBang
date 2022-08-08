using UnityEngine;

namespace BattleArena
{
    public class WeaponPickup : PickupItem
    {
        [SerializeField]
        private SpriteRenderer m_icon;
        [SerializeField]
        private WeaponData m_data;

        public void SetData(WeaponData data)
        {
            m_data = data;
            m_icon.sprite = data.icon;
        }

        protected override void Pickup(Collider2D collision)
        {
            collision.GetComponent<Weapon>().SetData(m_data);
        }

        private void Start()
        {
            if (m_data != null)
            {
                SetData(m_data);
            }
        }
    }
}