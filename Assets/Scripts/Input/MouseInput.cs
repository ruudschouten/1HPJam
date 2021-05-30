using Core;
using Events;
using UnityEngine;

namespace Input
{
    public class MouseInput : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private MonoRenderer player;
        [SerializeField] private float angleOffset;
        [SerializeField] private SpriteRenderer cursor;
        [SerializeField] private bool playerLooksAtMouse;

        [SerializeField] private IntegerEvent onMouseButtonPressed;

        private Vector2 _cursorPosition;

        private const int SupportedMouseButtons = 6;
        private readonly bool[] _currentMouseDown = new bool[SupportedMouseButtons];
        private readonly bool[] _previousMouseDown = new bool[SupportedMouseButtons];

        public void Update()
        {
            for (var i = 0; i < SupportedMouseButtons; i++)
            {
                _currentMouseDown[i] = UnityEngine.Input.GetMouseButtonDown(i);

                if (_currentMouseDown[i] && _currentMouseDown[i] != _previousMouseDown[i])
                {
                    onMouseButtonPressed.Invoke(i);
                }
            }

            LookAtMouse();

            for (var i = 0; i < SupportedMouseButtons; i++)
            {
                _previousMouseDown[i] = _currentMouseDown[i];
            }
        }

        public void LookAtMouse()
        {
            _cursorPosition = cam.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            if (playerLooksAtMouse)
            {
                // TODO: Fix this later.
                var angle = Helper.GetAngleAtTarget(_cursorPosition, player.transform.localPosition) - angleOffset;
                var eulerAngles = Quaternion.Euler(0, 0, angle).eulerAngles;
                player.transform.localRotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, -eulerAngles.z);
                cursor.transform.localRotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, -eulerAngles.z);
            }

            cursor.transform.position = _cursorPosition;
        }
    }
}