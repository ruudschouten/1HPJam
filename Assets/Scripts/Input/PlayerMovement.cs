using Characters;
using UnityEngine;

namespace Input
{
    public class PlayerMovement : Movement
    {
        [SerializeField] private Player player;
        private float _horizontal;
        private float _vertical;

        private void Update()
        {
            _horizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
            _vertical = UnityEngine.Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            if (!player.IsAlive) return;

            var movementVector = new Vector2((_horizontal * movementSpeed) * TimeScale,
                (_vertical * movementSpeed) * TimeScale);
            characterRenderer.Rigidbody.velocity = movementVector;
        }
    }
}