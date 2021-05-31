using System;
using Characters;
using Core;
using UnityEngine;
using UnityEngine.Events;

namespace Combat.Abilities
{
    public class MeleeBehaviour : MonoRenderer
    {
        [SerializeField] private Rigidbody2D holder;
        [SerializeField] private UnityEvent onEnemyHit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Enemy")) return;
            if (!(holder.angularVelocity >= 0.1)) return;
            onEnemyHit.Invoke();

            other.GetComponent<Character>().GetHit(DeathCause.Bullet);
        }
    }
}