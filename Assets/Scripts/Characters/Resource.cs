using Events;
using Scriptables;
using UnityEngine;

namespace Characters
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private IntegerReference mana; 
        [SerializeField] private IntegerReference energy;

        [SerializeField] private IntegerReferenceEvent onUseWithoutHavingRequiredAmount;
        [SerializeField] private IntegerReferenceEvent onManaUse;
        [SerializeField] private IntegerReferenceEvent onEnergyUse;

        public void UseResource(ResourceType type, int amount)
        {
            if (!HasRequiredResource(type, amount))
            {
                var resourceToUse = type == ResourceType.Mana ? mana : energy;
                onUseWithoutHavingRequiredAmount.Invoke(resourceToUse, amount);
                return;
            }
            // TODO: Check if -1 is needed.
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
                case ResourceType.Mana:
                    return mana.variable.value >= amount;
                case ResourceType.Energy:
                    return energy.variable.value >= amount;
            }

            return false;
        }
    }
}