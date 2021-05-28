using UnityEngine;

namespace Scriptables
{
    public abstract class ScriptableVariable<T> : ScriptableObject
    {
        public T value;

        public void SetValue(T value)
        {
            this.value = value;
        }

        public void SetValue(ScriptableVariable<T> value)
        {
            this.value = value.value;
        }

        public abstract void ApplyChange(T amount);

        public abstract void ApplyChange(ScriptableVariable<T> amount);
    }
}