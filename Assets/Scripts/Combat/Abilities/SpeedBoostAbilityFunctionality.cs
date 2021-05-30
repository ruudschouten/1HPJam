using System.Collections;
using System.Collections.Generic;
using Buildings;
using Characters;
using UnityEngine;

namespace Combat
{
    public class SpeedBoostAbilityFunctionality : AbilityFunctionality
    {
        [SerializeField] private float buildTimeScale = 5;
        [SerializeField] private float movementSpeedScale = 1.5f;

        private readonly List<BaseBuilding> _affectedBuildings = new List<BaseBuilding>();

        private const float DefaultTimeScale = 1;
        
        public override void Execute(Player player)
        {
            Active = true;

            player.Movement.TimeScale = movementSpeedScale;
            
            foreach (var building in player.BuildingsInRange)
            {
                building.Behaviour.TimeScale = buildTimeScale;
                _affectedBuildings.Add(building);
            }

            StartCoroutine(DurationRoutine(player));
        }

        public override IEnumerator DurationRoutine(Player player)
        {
            yield return new WaitForSeconds(duration);

            player.Movement.TimeScale = DefaultTimeScale;
            
            foreach (var building in _affectedBuildings)
            {
                building.Behaviour.TimeScale = DefaultTimeScale;
            }

            Active = false;
        }
    }
}