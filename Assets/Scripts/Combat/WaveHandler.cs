using System;
using System.Collections;
using System.Collections.Generic;
using Characters;
using PathCreation;
using TMPro;
using UnityEngine;

namespace Combat
{
    public class WaveHandler : MonoBehaviour
    {
        [SerializeField] private List<Wave> waves;
        [SerializeField] private Transform enemyContainer;
        [SerializeField] private TMP_Text countdownText;
        [SerializeField] private Player player;
        [SerializeField] private PathCreator path;

        private int _activeWave = -1;

        private Wave ActiveWave => waves[_activeWave];

        public void Start()
        {
            StartNextWave();
        }

        public void StartNextWave() 
        {
            if (HasNextWave())
            {
                _activeWave++;
                StartCoroutine(StartNextWaveDelayed());                    
            }
            else
            {
                // TODO: Either game complete, or next level.
            }
        }

        private void StartWave()
        {
            ActiveWave.StartWave(player, enemyContainer, path);
        }

        private bool HasNextWave()
        {
            return waves.Count - 1 > _activeWave;
        }

        private IEnumerator StartNextWaveDelayed()
        {
            var time = 0f;
            var remaining = 0f;
            countdownText.gameObject.SetActive(true);
            while (time < ActiveWave.TimeToWaitBeforeStartingWave)
            {
                yield return null;
                time += Time.deltaTime;
                
                remaining = ActiveWave.TimeToWaitBeforeStartingWave - time;
                countdownText.SetText(remaining.ToString("#"));
            }

            yield return null;
            
            countdownText.gameObject.SetActive(false);

            StartWave();
        }
    }
}