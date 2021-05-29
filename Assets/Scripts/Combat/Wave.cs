using System.Collections;
using System.Collections.Generic;
using Characters;
using PathCreation;
using UnityEngine;

namespace Combat
{
    public class Wave : MonoBehaviour
    {
        [SerializeField] private List<Enemy> enemiesToSpawnPerInterval;
        [SerializeField] private float interval;
        
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
                yield return new WaitForSeconds(interval);
            }
        }
    }
}