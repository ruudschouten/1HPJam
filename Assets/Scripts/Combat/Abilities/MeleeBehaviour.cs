using System;
using Characters;
using Core;
using UnityEngine;

namespace Combat.Abilities
{
    public class MeleeBehaviour : MonoRenderer
    {
        [SerializeField] private Rigidbody2D holder;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Enemy")) return;
            if (!(holder.angularVelocity >= 0.1)) return;

            other.GetComponent<Character>().GetHit();
        }
    }
}