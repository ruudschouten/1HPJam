using UnityEngine;
using UnityEngine.Events;

namespace Input
{
    public class MouseInput : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private Transform player;
        [SerializeField] private float angleOffset;
        [SerializeField] private SpriteRenderer cursor;
        [SerializeField] private bool lookAtMouse;

        [SerializeField] private UnityEvent onLeftMouseButtonPressed;

        private Vector2 _cursorPosition;
        private bool _currentLeftMouseDown;
        private bool _previousLeftMouseDown;

        public void Update()
        {
            _currentLeftMouseDown = UnityEngine.Input.GetMouseButtonDown(0);

            if (_currentLeftMouseDown && _currentLeftMouseDown != _previousLeftMouseDown)
            {
                onLeftMouseButtonPressed.Invoke();
            }

            if (lookAtMouse)
            {
                LookAtMouse();
            }

            _previousLeftMouseDown = _currentLeftMouseDown;
        }

        public void LookAtMouse()
        {
            _cursorPosition = camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            var angle = GetAngleAtTarget(_cursorPosition, player.transform.localPosition) - angleOffset;
            player.transform.localRotation = Quaternion.Euler(0, 0, angle);

            cursor.transform.position = _cursorPosition;
            cursor.transform.localRotation = Quaternion.Euler(0, 0, -angle);
        }

        public float GetAngleAtTarget(Vector3 targetPosition, Vector3 sourcePosition)
        {
            var radians = Mathf.Atan2(targetPosition.y - sourcePosition.y, targetPosition.x - sourcePosition.x);
            var degrees = (180 / Mathf.PI) * radians;

            return degrees;
        }
    }
}