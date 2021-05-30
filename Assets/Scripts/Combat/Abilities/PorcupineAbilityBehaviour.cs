using System.Collections;
using Characters;
using UnityEngine;

namespace Combat
{
    public class PorcupineAbilityBehaviour : AbilityFunctionality
    {
        [SerializeField] private Transform firePosition;
        [SerializeField] private float positionOffset;
        [SerializeField] private float angleOffset = 90;
        [SerializeField] private BulletBehaviour bulletPrefab;
        [SerializeField] private int bulletsToSpawn;
        
        public override void Execute(Player player)
        {
            var radians = 2 * Mathf.PI / bulletsToSpawn;
            for (var i = 0; i < bulletsToSpawn; i++)
            {
                var radian = radians * i;
                var horizontal = Mathf.Cos(radian);
                var vertical = Mathf.Sin(radian);
                var spawnDirection = new Vector3(horizontal, vertical, 0);
                var position = firePosition.position + spawnDirection * positionOffset;

                var rotation = Quaternion.Euler(0, 0, (radian * Mathf.Rad2Deg) - angleOffset);
                Instantiate(bulletPrefab, position, rotation);
            }
        }

        public override IEnumerator DurationRoutine(Player player)
        {
            // Isn't needed for this behaviour.
            throw new System.NotImplementedException();
        }
    }
}