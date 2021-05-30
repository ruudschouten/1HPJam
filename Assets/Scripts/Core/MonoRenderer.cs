using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class MonoRenderer : MonoBehaviour
    {
        [SerializeField] protected new Rigidbody2D rigidbody;
        [SerializeField] protected new SpriteRenderer renderer;

        public Rigidbody2D Rigidbody
        {
            get => rigidbody;
            set => rigidbody = value;
        }

        public SpriteRenderer Renderer
        {
            get => renderer;
            set => renderer = value;
        }
    }
}