using Characters;
using UnityEngine;

namespace Input
{
    public class PlayerMovement : Movement
    {
        private float _horizontal;
        private float _vertical;

        private void Update()
        {
            _horizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
            _vertical = UnityEngine.Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            var movementVector = new Vector2(_horizontal * movementSpeed, _vertical * movementSpeed);
            character.Rigidbody.velocity = movementVector;
        }
    }
}