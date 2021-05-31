using System;
using Characters;
using UnityEngine;

namespace Buildings
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class PlacementArea : MonoBehaviour
    {
        [SerializeField] private AreaType areaType;

        public AreaType AreaType => areaType;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (AreaType != AreaType.Water) return;
            if (!other.CompareTag("Player")) return;

            other.GetComponent<Player>().GetHit(DeathCause.Drowned);
        }
    }
}