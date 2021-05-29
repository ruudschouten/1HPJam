using Characters;
using PathCreation;
using UnityEngine;

namespace Input
{
    public class EnemyMovement : Movement
    {
        [SerializeField] private PathCreator pathCreator;
        [SerializeField] private EndOfPathInstruction endOfPathInstruction;

        private float _distanceTravelled;

        public void TravelToNextPoint()
        {
            _distanceTravelled += movementSpeed * Time.deltaTime; 
            character.transform.position = pathCreator.path.GetPointAtDistance(_distanceTravelled, endOfPathInstruction);
        }
    }
}