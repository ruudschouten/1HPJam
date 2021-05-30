using Characters;
using Core;
using UnityEngine;

namespace Combat
{
    public class BulletBehaviour : MonoRenderer
    {
        [SerializeField] private float speed;
        [SerializeField] private float speedIncrease = 1.25f;
        [SerializeField] private Character target;
        [SerializeField] private float angleOffset = 180;

        private bool _hasTarget;
        private float _chaseTimer;

        // Stay alive for 10 seconds.
        private const float DestroyTimer = 10f;
        private float _timer;

        public void StartChasing(Character targetToChase)
        {
            target = targetToChase;
            _hasTarget = true;
        }

        public void Update()
        {
            _timer += Time.deltaTime;
            // Increase speed every tick
            speed += speedIncrease * Time.deltaTime;

            if (_timer >= DestroyTimer)
            {
                Destroy(gameObject);
                return;
            }

            if (!_hasTarget || target == null)
            {
                // Move forward
                transform.position += transform.right * (Time.deltaTime * speed);
            }
            else
            {
                ChaseTarget();
            }
        }

        private void ChaseTarget()
        {
            _chaseTimer = Time.deltaTime * speed;

            var angle = Helper.GetAngleAtTarget(target.transform.position, transform.position);

            transform.rotation = Quaternion.Euler(0, 0, angle - angleOffset);

            var position = Vector2.Lerp(transform.position, target.transform.position, _chaseTimer);
            transform.position = position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Shield"))
            {
                Destroy(gameObject);
            }
            
            if (!other.CompareTag("Player") && !other.CompareTag("Enemy")) return;

            other.GetComponent<Character>().GetHit();
            Destroy(gameObject);
        }
    }
}