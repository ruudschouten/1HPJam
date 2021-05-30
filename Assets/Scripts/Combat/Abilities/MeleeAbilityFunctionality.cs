using System.Collections;
using Characters;
using Core;
using UnityEngine;

namespace Combat.Abilities
{
    public class MeleeAbilityFunctionality : AbilityFunctionality
    {
        [SerializeField] private Rigidbody2D holder;
        [SerializeField] private float torqueToAdd;
        
        public override void Execute(Player player)
        {
            var impulse = (torqueToAdd * Mathf.Deg2Rad) * holder.inertia;
            holder.AddTorque(impulse, ForceMode2D.Impulse);
        }

        public override IEnumerator DurationRoutine(Player player)
        {
            // Isn't needed for this behaviour.
            throw new System.NotImplementedException();
        }
    }
}