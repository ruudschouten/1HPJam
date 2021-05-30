using System;
using System.Collections;
using Characters;
using Events;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Combat
{
    public class Ability : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private AbilityFunctionality functionality;
        [SerializeField] private int resourceAmountToUse;
        [SerializeField] private bool hasCooldown;
        [SerializeField] private float cooldown;

        [Foldout("UI")] [SerializeField] private Image cooldownImage;

        [Foldout("Events")] [SerializeField] private AbilityEvent onAbilityUse;
        [Foldout("Events")] [SerializeField] private AbilityEvent onAbilityCooldownStart;
        [Foldout("Events")] [SerializeField] private AbilityTimeEvent onAbilityCooldownUpdated;
        [Foldout("Events")] [SerializeField] private AbilityEvent onAbilityCooldownOver;

        private float _currentCooldown;
        private bool _isOnCooldown;

        public void Use(Resource resource)
        {
            Debug.Log($"You have pressed the button for {name}");

            if (!CanUseAbility(resource))
            {
                return;
            }

            if (functionality.IsActive) return;

            functionality.Execute(player);

            onAbilityUse.Invoke(this);
            if (hasCooldown)
            {
                StartCoroutine(CooldownRoutine());
            }
        }

        private bool CanUseAbility(Resource resource)
        {
            return resource.HasRequiredResource(resourceAmountToUse);
        }

        private IEnumerator CooldownRoutine()
        {
            _isOnCooldown = true;
            _currentCooldown = 0f;
            var percentage = 1f;
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
                
                percentage = 1f - (_currentCooldown / cooldown);
                cooldownImage.fillAmount = percentage;

                yield return null;
            }

            onAbilityCooldownOver.Invoke(this);
        }
    }
}