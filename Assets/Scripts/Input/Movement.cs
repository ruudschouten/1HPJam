using Core;
using UnityEngine;

namespace Input
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] protected float movementSpeed;
        [SerializeField] protected MonoRenderer characterRenderer;

        public float TimeScale { get; set; } = 1;
    }
}