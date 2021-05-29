using System;
using Core;
using Events;
using UnityEngine;

namespace Characters
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] protected float movementSpeed;
        [SerializeField] protected MonoRenderer character;

        [SerializeField] protected MovementEvent onMove;
    }
}