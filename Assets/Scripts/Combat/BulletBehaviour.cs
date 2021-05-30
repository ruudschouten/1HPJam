using Characters;
using Core;
using UnityEngine;

namespace Combat
{
    public class BulletBehaviour : MonoRenderer
    {
        [SerializeField] private float speed;
        [SerializeField] private float speedIncrease = 1.0125f;
        [SerializeField] private Character target;
        [SerializeField] private float angleOffset = 180;

        private bool _hasTarget = true;
        private float _timer;

        public void StartChasing(Character targetToChase)
        {
            target = targetToChase;
            _hasTarget = true;
        }

        public void Update()
        {
            if (!_hasTarget) return;

            if (target == null)
            {
                Destroy(gameObject);
                return;
            }
            
            // Increase speed every tick
            speed *= speedIncrease;
            
            _timer = Time.deltaTime * speed;
            
            var angle = Helper.GetAngleAtTarget(target.transform.position, transform.position);
            
            transform.rotation = Quaternion.Euler(0, 0, angle - angleOffset);
            
            var position = Vector2.Lerp(transform.position, target.transform.position, _timer);
            transform.position = position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player") && !other.CompareTag("Enemy")) return;

            other.GetComponent<Character>().GetHit();
            Destroy(gameObject);
        }
    }
}