using System;
using Events;
using Scriptables;
using UnityEngine;

namespace Characters
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private IntegerReference maxMana;
        [SerializeField] private IntegerReference maxEnergy;
        [SerializeField] private IntegerReference mana;
        [SerializeField] private IntegerReference energy;

        [SerializeField] private IntegerReferenceEvent onUseWithoutHavingRequiredAmount;
        [SerializeField] private IntegerReferenceEvent onManaUse;
        [SerializeField] private IntegerReferenceEvent onEnergyUse;

        private void Awake()
        {
            mana.Value = maxMana.Value;
            energy.Value = maxEnergy.Value;
        }

        public void ReceiveResource(ResourceType type, int amount)
        {
            var resourceToUse = type == ResourceType.Mana ? mana : energy;
            var resourceMax = type == ResourceType.Mana ? maxMana : maxEnergy;

            resourceToUse.variable.ApplyChange(amount);
            if (resourceToUse.Value >= resourceMax.Value)
            {
                resourceToUse.Value = resourceMax.Value;
            }
        }

        public void UseResource(ResourceType type, int amount)
        {
            if (!HasRequiredResource(type, amount))
            {
                var resourceToUse = type == ResourceType.Mana ? mana : energy;
                onUseWithoutHavingRequiredAmount.Invoke(resourceToUse, amount);
                return;
            }

            switch (type)
            {
                case ResourceType.Mana:
                    mana.variable.ApplyChange(-amount);
                    onManaUse.Invoke(mana, amount);
                    break;
                case ResourceType.Energy:
                    energy.variable.ApplyChange(-amount);
                    onEnergyUse.Invoke(energy, amount);
                    break;
            }
        }

        public bool HasRequiredResource(ResourceType type, int amount)
        {
            switch (type)
            {
                case ResourceType.None:
                    return true;
                case ResourceType.Mana:
                    return mana.variable.value >= amount;
                case ResourceType.Energy:
                    return energy.variable.value >= amount;
            }

            return false;
        }
    }
}