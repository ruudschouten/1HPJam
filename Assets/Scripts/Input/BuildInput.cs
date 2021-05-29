using Characters;
using Core;
using UnityEngine;

namespace Input
{
    public class BuildInput : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private Resource resource;
        [SerializeField] private Transform buildParent;
        [SerializeField] private RectTransform buildMenu;
        [SerializeField] private SpriteRenderer heldItem;
        [SerializeField] private KeyCode placeKey = KeyCode.E;
        [SerializeField] private KeyCode showBuildMenu = KeyCode.Tab;

        private bool _previousPlaceKey;
        private bool _currentPlaceKey;
        private bool _previousMenuKey;
        private bool _currentMenuKey;

        public void Update()
        {
            _currentMenuKey = UnityEngine.Input.GetKeyDown(showBuildMenu);

            if (_currentMenuKey && _currentMenuKey != _previousMenuKey)
            {
               ToggleMenu();
            }

            if (player.GameState != GameState.Building)
            {
                return;
            }

            _currentPlaceKey = UnityEngine.Input.GetKeyDown(placeKey);

            if (_currentPlaceKey && _currentPlaceKey != _previousPlaceKey)
            {
                PlaceBuildingIfPossible();
            }

            _previousPlaceKey = _currentPlaceKey;
            _previousMenuKey = _currentMenuKey;
        }

        private void ToggleMenu()
        {
            if (player.GameState == GameState.Building)
            {
                player.GameState = GameState.Combat;
                buildMenu.gameObject.SetActive(false);

                heldItem.sprite = null;
                heldItem.gameObject.SetActive(false);
            }
            else
            {
                player.GameState = GameState.Building;

                buildMenu.gameObject.SetActive(true);
                heldItem.gameObject.SetActive(true);
            }
        }

        private void PlaceBuildingIfPossible()
        {
            if (player.ActiveBuilding == null) return;
            if (!player.ActiveBuilding.CanPurchaseDownBuilding(resource)) return;
            if (!player.ActiveBuilding.CheckPlacementConstraint(player.Cam)) return;

            player.ActiveBuilding.Place(buildParent, player.Cam, resource);
        }
    }
}