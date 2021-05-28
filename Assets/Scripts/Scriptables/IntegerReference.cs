using System;

namespace Scriptables
{
    [Serializable]
    public class IntegerReference
    {
        public bool useConstant = true;
        public int constantValue;
        public IntegerVariable variable;

        public IntegerReference()
        {
        }

        public IntegerReference(int value)
        {
            useConstant = true;
            constantValue = value;
        }

        public int Value
        {
            get => useConstant ? constantValue : variable.value;
            set
            {
                if (useConstant) constantValue = value;
                else variable.value = value;
            }
        }

        public static implicit operator int(IntegerReference reference)
        {
            return reference.Value;
        }
    }
}