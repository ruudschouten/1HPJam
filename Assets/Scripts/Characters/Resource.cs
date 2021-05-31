using Events;
using Scriptables;
using UnityEngine;

namespace Characters
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private IntegerReference maxEnergy;
        [SerializeField] private IntegerReference energy;

        [SerializeField] private IntegerReferenceEvent onUseWithoutHavingRequiredAmount;
        [SerializeField] private IntegerReferenceEvent onEnergyUse;
        [SerializeField] private IntegerReferenceEvent onEnergyReceive;

        private void Awake()
        {
            energy.Value = maxEnergy.Value;
        }

        public void ReceiveResource(int amount)
        {
            energy.variable.ApplyChange(amount);
            onEnergyReceive.Invoke(energy, amount);
            if (energy.Value >= maxEnergy.Value)
            {
                energy.Value = maxEnergy.Value;
            }
        }

        public void UseResource(int amount)
        {
            if (!HasRequiredResource(amount))
            {
                onUseWithoutHavingRequiredAmount.Invoke(energy, amount);
                return;
            }

            energy.variable.ApplyChange(-amount);
            onEnergyUse.Invoke(energy, amount);
        }

        public bool HasRequiredResource(int amount)
        {
            return energy.variable.value >= amount;
        }
    }
}