using System.Collections;
using Characters;
using UnityEngine;

namespace Combat
{
    public abstract class AbilityFunctionality : MonoBehaviour
    {
        [SerializeField] protected float duration = 1.5f;

        protected bool Active = false;

        public bool IsActive => Active;
        
        public abstract void Execute(Player player);

        public abstract IEnumerator DurationRoutine(Player player);
    }
}