using UnityEngine;

namespace BattleArena
{
    public class BasicBullet : Bullet
    {

    }

    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField]
        protected float m_speed = 30;
        [SerializeField]
        protected BulletData m_data;

        protected Rigidbody2D m_rigidbody;

        public void SetSpeed(float speed)
        {
            m_speed = speed;
        }

        public void ForceCollision()
        {
            OnCollision(null);
        }

        protected virtual void OnCollision(Collider2D collision)
        {
            Destroy(gameObject);
            Instantiate(m_data.impactFx, transform.position, transform.rotation);
        }

        protected virtual void MoveBullet()
        {
            if(m_rigidbody != null)
            {
                m_rigidbody.velocity = transform.right * m_speed;
            }
        }

        private bool IsCollidable(Collider2D collider) => collider.CompareTag("Wall") || collider.CompareTag("Hitbox");

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            MoveBullet();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var collider = collision.collider;
            if (IsCollidable(collider))
                OnCollision(collider);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsCollidable(collision))
                OnCollision(collision);
        }
    }

}