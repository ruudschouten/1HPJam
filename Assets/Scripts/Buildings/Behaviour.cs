using System;
using System.Collections;
using System.Collections.Generic;
using Characters;
using Combat;
using Core;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Buildings
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Behaviour : MonoBehaviour
    {
        [SerializeField] private TargetType targetType;
        
        [SerializeField] private BulletBehaviour bulletPrefab;
        [SerializeField] private Transform aimIndicatorHolder;
        [SerializeField] private Transform aimIndicator;
        [SerializeField] private float aimIndicatorAngleOffset = 90;
        [SerializeField] private GameObject fastForwardIndicator; 
        
        [SerializeField] private float attackSpeed = 2.5f;
        [SerializeField] private float timeScale = 1;
        [SerializeField] private UnityEvent onBulletShot;

        private List<Enemy> _enemiesInRange = new List<Enemy>();
        [CanBeNull] private Enemy _target;
        private float _currentTargetDistance;

        private bool _isOnCooldown;
        private float _currentCooldown;

        private const string EnemyTag = "Enemy";

        public float TimeScale
        {
            get => timeScale;
            set
            {
                timeScale = value;
                if (timeScale > 1) fastForwardIndicator.SetActive(true);
                else fastForwardIndicator.SetActive(false);
            }
        }

        private void Update()
        {
            foreach (var enemy in _enemiesInRange)
            {
                switch (targetType)
                {
                    case TargetType.Closest:
                        HandleClosestBehaviour(enemy);
                        break;
                    case TargetType.Farthest:
                        HandleFarthestBehaviour(enemy);
                        break;
                }
            }

            if (_target == null) return;

            var angle = Helper.GetAngleAtTarget(_target.transform.position, transform.position);
            aimIndicatorHolder.rotation = Quaternion.Euler(0, 0, angle - aimIndicatorAngleOffset);

            Attack();
        }

        private void Attack()
        {
            if (_isOnCooldown) return;

            var bullet = Instantiate(bulletPrefab, aimIndicator.position, Quaternion.identity);
            bullet.StartChasing(_target);
            onBulletShot.Invoke();

            StartCoroutine(CooldownRoutine());
        }

        private IEnumerator CooldownRoutine()
        {
            _isOnCooldown = true;
            _currentCooldown = 0f;
            yield return null;
            while (_isOnCooldown)
            {
                _currentCooldown += Time.deltaTime * timeScale;
                if (Math.Abs(_currentCooldown - attackSpeed) < 0.01f)
                {
                    _isOnCooldown = false;
                }

                yield return null;
            }
        }

        private void OnTargetDies(Enemy enemy)
        {
            _enemiesInRange.Remove(enemy);
            if (enemy == _target)
            {
                _target = null;
            }
        }

        #region Behaviour Handling

        private void HandleClosestBehaviour(Enemy enemy)
        {
            if (enemy == null) return;
            var distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (_target == null || distance >= _currentTargetDistance)
            {
                _target = enemy;
                _currentTargetDistance = distance;
            }
        }

        private void HandleFarthestBehaviour(Enemy enemy)
        {
            if (enemy == null) return;
            var distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (_target == null || distance <= _currentTargetDistance)
            {
                _target = enemy;
                _currentTargetDistance = distance;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(EnemyTag))
            {
                var enemy = other.GetComponent<Enemy>();
                // Add a listener to all enemies in range so they get automatically removed if they die.
                enemy.OnDeath.AddListener(call => OnTargetDies(enemy));
                _enemiesInRange.Add(enemy);

                if (targetType == TargetType.Newest)
                {
                    _target = enemy;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(EnemyTag))
            {
                var enemy = other.GetComponent<Enemy>();
                _enemiesInRange.Remove(enemy);
                if (_target == enemy)
                {
                    _target = null;
                }
            }
        }

        #endregion
    }
}