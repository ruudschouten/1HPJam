using System.Collections.Generic;
using Characters;
using NaughtyAttributes;
using PathCreation;
using UnityEngine;

namespace Combat
{
    public class WaveHandler : MonoBehaviour
    {
        [SerializeField] private List<Wave> waves;
        [SerializeField] private Transform enemyContainer;
        [SerializeField] private Player player;
        [SerializeField] private PathCreator path;
        
        // TODO: When should a new wave start?
        [Button("Start Wave")]
        public void StartWave()
        {
            waves[0].StartWave(player, enemyContainer, path);
        }
    }
}