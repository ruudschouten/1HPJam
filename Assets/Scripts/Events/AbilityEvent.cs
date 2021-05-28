using System;
using Combat;
using UnityEngine.Events;

namespace Events
{
    [Serializable] public class AbilityEvent : UnityEvent<Ability> { }

    [Serializable]
    public class AbilityTimeEvent : UnityEvent<Ability, double>
    {
        // Ability and its current cooldown
    }
}