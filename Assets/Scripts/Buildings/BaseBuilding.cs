using System;
using System.Collections.Generic;
using System.Linq;
using Characters;
using UnityEngine;
using UnityEngine.Events;

namespace Buildings
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class BaseBuilding : MonoBehaviour
    {
        [SerializeField] private ResourceType type;
        [SerializeField] private int buildCost;
        [SerializeField] private AreaType placementConstraint;

        private BuildingState _buildingState;
        private Player _player;
        private bool _foundPlayer;

        private const string PlayerAreaOfEffectTag = "PlayerAreaOfEffect";
        private const string PlacementTag = "Placement";
        private const string BuildingTag = "Building";

        public BuildingState BuildingState
        {
            get => _buildingState;
            set => _buildingState = value;
        }

        public bool CanPurchaseDownBuilding(Resource resource)
        {
            return resource.HasRequiredResource(type, buildCost);
        }

        public bool CheckPlacementConstraint(Camera cam)
        {
            // Get mouse position
            var cursorPosition = cam.ScreenToWorldPoint(UnityEngine.Input.mousePosition);

            var hits = new RaycastHit2D[50];
            var size = Physics2D.RaycastNonAlloc(cursorPosition, Vector2.zero, hits);
            if (size == 0) return false;

            foreach (var hit in hits)
            {
                if (hit.collider == null) continue;
                if (string.IsNullOrEmpty(hit.transform.tag)) continue;
                if (hit.transform.CompareTag(BuildingTag)) return false; // Another building is already placed here.
                if (!hit.transform.CompareTag(PlacementTag)) continue;

                //TODO: Should be replaced if performance gets really bad.
                var areaType = hit.transform.GetComponent<PlacementArea>().AreaType;
                return placementConstraint.Equals(areaType);
            }

            return false;
        }

        public void Place(Transform buildingParent, Camera cam, Resource resource)
        {
            // First consume the resources.
            resource.UseResource(type, buildCost);

            // Then place it.
            var building = Instantiate(this, buildingParent);
            var position = cam.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            position.z = 0;
            building.transform.position = position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(PlayerAreaOfEffectTag))
            {
                if (!_foundPlayer)
                {
                    _player = other.attachedRigidbody.GetComponent<Player>();
                    _foundPlayer = true;
                }

                _player.AddBuildingInRange(this);
            }

            // TODO: Consider if this needs to also look at other buildings.
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(PlayerAreaOfEffectTag))
            {
                _player.RemoveBuildingInRange(this);
            }
        }
    }
}