using System;
using System.Collections;
using Combat;
using Core;
using UnityEngine;
using UnityEngine.Events;

namespace Characters
{
    public class ShootingEnemy : Enemy
    {
        [SerializeField] private BulletBehaviour projectilePrefab;
        [SerializeField] private float shootingInterval;
        [SerializeField] private Transform fireHolder;
        [SerializeField] private Transform firePosition;
        [SerializeField] private float angleOffset = 180;
        [SerializeField] private UnityEvent onShoot;

        private bool _isOnCooldown = true;
        private float _currentCooldown;

        private void Start()
        {
            StartCoroutine(CooldownRoutine());
        }

        public void Update()
        {
            base.Update();
            
            var angle = Helper.GetAngleAtTarget(transform.position, Player.transform.position);
            var rotation = Quaternion.Euler(0, 0, angle - angleOffset);
            fireHolder.transform.rotation = rotation;

            if (_isOnCooldown) return;

            StopAllCoroutines();
            
            Shoot();
            StartCoroutine(CooldownRoutine());
        }

        private void Shoot()
        {
            Instantiate(projectilePrefab, firePosition.position, Quaternion.identity);
            onShoot.Invoke();
        }

        private IEnumerator CooldownRoutine()
        {
            _isOnCooldown = true;
            _currentCooldown = 0f;
            yield return null;
            while (_isOnCooldown)
            {
                _currentCooldown += Time.deltaTime;
                if (Math.Abs(_currentCooldown - shootingInterval) < 0.01f)
                {
                    _isOnCooldown = false;
                }

                yield return null;
            }
        }
    }
}