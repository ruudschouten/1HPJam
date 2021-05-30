using PathCreation;
using UnityEngine;

namespace Input
{
    public class EnemyMovement : Movement
    {
        [SerializeField] private Transform parent;
        [SerializeField] private PathCreator pathCreator;
        [SerializeField] private EndOfPathInstruction endOfPathInstruction = EndOfPathInstruction.Stop;

        private float _distanceTravelled;

        public PathCreator Path
        {
            get => pathCreator;
            set => pathCreator = value;
        }

        public void TravelToNextPoint()
        {
            _distanceTravelled += movementSpeed * Time.deltaTime;
            parent.position = pathCreator.path.GetPointAtDistance(_distanceTravelled, endOfPathInstruction);
        }
    }
}