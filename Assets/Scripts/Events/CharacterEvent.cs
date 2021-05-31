using System;
using Characters;
using UnityEngine.Events;

namespace Events
{
    [Serializable]
    public class CharacterEvent : UnityEvent<Character>
    {
    }

    [Serializable]
    public class CharacterIntEvent : UnityEvent<Character, int>
    {
        // Character, and hit for
    }

    [Serializable]
    public class CharacterHitEvent : UnityEvent<DeathCause>
    {
    }
}