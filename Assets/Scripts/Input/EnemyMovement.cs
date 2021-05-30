using Characters;
using PathCreation;
using UnityEngine;

namespace Input
{
    public class EnemyMovement : Movement
    {
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
            characterRenderer.transform.position = pathCreator.path.GetPointAtDistance(_distanceTravelled, endOfPathInstruction);
        }
    }
}