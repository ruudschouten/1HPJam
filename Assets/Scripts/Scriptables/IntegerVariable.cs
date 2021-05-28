using UnityEngine;

namespace Scriptables
{    
    [CreateAssetMenu(menuName = "Scriptables/Variables/Integer")]
    public class IntegerVariable : ScriptableVariable<int>
    {
        public override void ApplyChange(int amount)
        {
            value += amount;
        }

        public override void ApplyChange(ScriptableVariable<int> amount)
        {
            value += amount.value;
        }
    }
}