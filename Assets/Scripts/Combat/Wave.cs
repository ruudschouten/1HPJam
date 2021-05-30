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

        public void StartWave(Player player, Transform container, IReadOnlyList<PathCreator> paths)
        {
            StartCoroutine(SpawnRoutine(player, container, paths));
        }

        private IEnumerator SpawnRoutine(Player player, Transform container, IReadOnlyList<PathCreator> paths)
        {
            yield return null;
            var pathIndex = 0;
            foreach (var enemy in enemiesToSpawnPerInterval)
            {
                yield return null;
                var prefab = Instantiate(enemy, container);
                prefab.Player = player;
                prefab.Movement.Path = paths[pathIndex];

                pathIndex = (paths.Count - 1) > pathIndex ? pathIndex + 1 : 0;

                prefab.OnDeath.AddListener(call => EnemyKilled(prefab));
                _spawnedEnemies.Add(prefab);
                yield return new WaitForSeconds(interval);
            }
        }
    }
}