using Core;
using Events;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace Characters
{
    public class Character : MonoRenderer
    {
        [SerializeField] protected int health = 1;
        [SerializeField] protected Resource resource;

        [Foldout("Events")] [SerializeField] private UnityEvent onHit;
        [Foldout("Events")] [SerializeField] private UnityEvent onDeath;
        [Foldout("Events")] [SerializeField] private CharacterEvent onCharacterHit;

        // TODO: Add functions for collision
    }
}