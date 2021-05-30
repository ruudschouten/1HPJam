using System.Collections;
using System.Collections.Generic;
using Characters;
using PathCreation;
using UnityEngine;
using UnityEngine.Events;

namespace Combat
{
    public class Wave : MonoBehaviour
    {
        [SerializeField] private UnityEvent onWaveCompleted;
        [SerializeField] private List<Enemy> enemiesToSpawnPerInterval;
        [SerializeField] private float timeToWaitBeforeStartingWave;
        [SerializeField] private float interval;

        private List<Character> _spawnedEnemies = new List<Character>();
        private int _enemiesKilled = 0;

        public bool WaveComplete => enemiesToSpawnPerInterval.Count == _enemiesKilled;

        public float TimeToWaitBeforeStartingWave => timeToWaitBeforeStartingWave;

        public void EnemyKilled(Character character)
        {
            if (_spawnedEnemies.Contains(character))
            {
                _enemiesKilled++;
            }

            if (WaveComplete)
            {
                onWaveCompleted.Invoke();
            }
        }
        
        public void StartWave(Player player, Transform container, PathCreator path)
        {
            StartCoroutine(SpawnRoutine(player, container, path));
        }

        private IEnumerator SpawnRoutine(Player player, Transform container, PathCreator path)
        {
            yield return null;
            foreach (var enemy in enemiesToSpawnPerInterval)
            {
                yield return null;
                var prefab = Instantiate(enemy, container);
                prefab.Player = player;
                prefab.Movement.Path = path;
                prefab.OnDeath.AddListener(call => EnemyKilled(prefab));
                _spawnedEnemies.Add(prefab);
                yield return new WaitForSeconds(interval);
            }
        }
    }
}