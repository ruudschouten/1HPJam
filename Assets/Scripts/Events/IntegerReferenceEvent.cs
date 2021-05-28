using System;
using Scriptables;
using UnityEngine.Events;

namespace Events
{
    [Serializable] public class IntegerEvent : UnityEvent<int> { }

    [Serializable] public class IntegerReferenceEvent : UnityEvent<IntegerReference, int>{ }
}