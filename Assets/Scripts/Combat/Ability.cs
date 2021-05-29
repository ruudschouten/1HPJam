using System;
using System.Collections;
using Characters;
using Events;
using UnityEngine;

namespace Combat
{
    public class Ability : MonoBehaviour
    {
        [SerializeField] private string abilityName;
        [SerializeField] private ResourceType resourceType;
        [SerializeField] private int resourceAmountToUse;
        [SerializeField] private bool hasCooldown;
        [SerializeField] private float cooldown;
        
        [Header("Events")]
        [SerializeField] private AbilityEvent onAbilityUse;
        [SerializeField] private AbilityEvent onAbilityCooldownStart;
        [SerializeField] private AbilityTimeEvent onAbilityCooldownUpdated;
        [SerializeField] private AbilityEvent onAbilityCooldownOver;

        private float _currentCooldown;
        private bool _isOnCooldown;

        public void Use(Resource resource)
        {
            Debug.Log($"You have pressed the button for {abilityName}");

            if (!CanUseAbility(resource))
            {
                return;
            }
            
            onAbilityUse.Invoke(this);
            if (hasCooldown)
            {
                StartCoroutine(CooldownRoutine());
            }
        }

        private bool CanUseAbility(Resource resource)
        {
            return resource.HasRequiredResource(resourceType, resourceAmountToUse);
        }

        private IEnumerator CooldownRoutine()
        {
            _isOnCooldown = true;
            _currentCooldown = 0f;
            onAbilityCooldownStart.Invoke(this);
            yield return null;
            while (_isOnCooldown)
            {
                _currentCooldown += Time.deltaTime;
                onAbilityCooldownUpdated.Invoke(this, _currentCooldown);
                if (Math.Abs(_currentCooldown - cooldown) < 0.01f)
                {
                    _isOnCooldown = false;
                }

                yield return null;
            }
            onAbilityCooldownOver.Invoke(this);
        }
    }
}