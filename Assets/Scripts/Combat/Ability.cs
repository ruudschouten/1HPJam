using System;
using System.Collections;
using Characters;
using Events;
using UnityEngine;

namespace Combat
{
    public class Ability : MonoBehaviour
    {
        [SerializeField] private string name;
        [SerializeField] private ResourceType resourceType;
        [SerializeField] private int resourceAmountToUse;
        [SerializeField] private bool hasCooldown;
        [SerializeField] private float cooldown;
        
        [Header("Events")]
        [SerializeField] private AbilityEvent onAbilityUse;
        [SerializeField] private AbilityEvent onAbilityCooldownStart;
        [SerializeField] private AbilityTimeEvent onAbilityCooldownUpdated;

        private float _currentCooldown = -1;
        private bool _isOnCooldown = false;

        public void Use()
        {
            // TODO do this :)
            
            onAbilityUse.Invoke(this);
            if (hasCooldown)
            {
                StartCoroutine(CooldownRoutine());
            }
        }

        private bool CanUseAbility(ResourceType type, Resource resource)
        {
            return resource.HasRequiredResource(type, resourceAmountToUse);
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
            }
        }
    }
}