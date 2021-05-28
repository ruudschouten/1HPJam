using Core;
using Events;
using UnityEngine;
using UnityEngine.Events;

namespace Characters
{
    public class Character : MonoRenderer
    {
        [SerializeField] private int health = 1;
        [SerializeField] private Resource resource;

        [Header("Events")]
        [SerializeField] private UnityEvent onHit;
        [SerializeField] private UnityEvent onDeath;
        [SerializeField] private CharacterEvent onCharacterHit;
        [SerializeField] private CharacterIntEvent onCharacterDamaged;
        [SerializeField] private UnityEvent<float> onNearDodge;
    }
}