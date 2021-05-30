using System;
using UnityEngine;

namespace Combat.Abilities
{
    public class MeleeHolder : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;

        private void Update()
        {
            transform.localPosition = Vector3.zero;
            rigidbody.position = Vector2.zero;
        }
    }
}