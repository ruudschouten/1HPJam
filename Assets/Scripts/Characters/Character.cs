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

        [Foldout("Events")] [SerializeField] private CharacterHitEvent onHit;
        [Foldout("Events")] [SerializeField] private CharacterEvent onDeath;
        [Foldout("Events")] [SerializeField] private CharacterEvent onCharacterHit;

        public bool IsAlive => health > 0;
        public CharacterEvent OnDeath => onDeath;

        public void GetHit(DeathCause cause)
        {
            health = 0;
            onHit.Invoke(cause);
            onDeath.Invoke(this);
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}