using UnityEngine;

namespace Buildings
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class PlacementArea : MonoBehaviour
    {
        [SerializeField] private AreaType areaType;

        public AreaType AreaType => areaType;
    }
}