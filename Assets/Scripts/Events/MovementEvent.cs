using System;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    [Serializable]
    public class MovementEvent : UnityEvent<Vector2, float> { }
}