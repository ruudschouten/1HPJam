using System;
using System.Collections.Generic;
using Buildings;
using Core;
using Events;
using JetBrains.Annotations;
using NaughtyAttributes;
using UnityEngine;

namespace Characters
{
    public class Player : Character
    {
        [SerializeField] private Camera cam;
        [SerializeField] private GameState _gameState;
        [SerializeField] private SpriteRenderer affectedArea;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color validPlacementColor;
        [SerializeField] private Color invalidPlacementColor;
        [SerializeField] [CanBeNull] private BaseBuilding activeBuilding;
        [SerializeField] private List<BaseBuilding> buildingsInRange;

        [Foldout("Building Events")] [SerializeField]
        private BuildingEvent onBuildingInRange;

        [Foldout("Building Events")] [SerializeField]
        private BuildingEvent onBuildingOutOfRange;

        public GameState GameState
        {
            get => _gameState;
            set => _gameState = value;
        }

        [CanBeNull]
        public BaseBuilding ActiveBuilding
        {
            get => activeBuilding;
            set => activeBuilding = value;
        }

        public Camera Cam => cam;

        public void AddBuildingInRange(BaseBuilding building)
        {
            if (buildingsInRange.Contains(building))
            {
                return;
            }

            buildingsInRange.Add(building);
            onBuildingInRange.Invoke(building);
        }

        public void RemoveBuildingInRange(BaseBuilding building)
        {
            buildingsInRange.Remove(building);
            onBuildingOutOfRange.Invoke(building);
        }

        private void Update()
        {
            UpdateAreaColor();
        }

        public void UpdateAreaColor()
        {
            if (_gameState != GameState.Building)
            {
                affectedArea.color = defaultColor;
                return;
            }
            if (activeBuilding == null)
            {
                affectedArea.color = defaultColor;
                return;
            }
            if (activeBuilding.BuildingState != BuildingState.Placement)
            {
                affectedArea.color = defaultColor;
                return;
            }

            if (!activeBuilding.CanPurchaseDownBuilding(resource))
            {
                affectedArea.color = invalidPlacementColor;
                return;
            }

            var canPlaceBuilding = activeBuilding.CheckPlacementConstraint(cam);
            affectedArea.color = canPlaceBuilding ? validPlacementColor : invalidPlacementColor;
        }
    }
}