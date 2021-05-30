using Input;
using UnityEngine;

namespace Characters
{
    public class Enemy : Character
    {
        [SerializeField] private Player player;
        [SerializeField] private EnemyMovement movement;

        private const string PlayerTag = "Player";
        private const string FinishTag = "FinishLine";
        
        public Player Player
        {
            get => player;
            set => player = value;
        }
        public EnemyMovement Movement => movement;

        private void Update()
        {
            // Follow the path laid out.
            movement.TravelToNextPoint();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(PlayerTag))
            {
                player.GetHit();
            }

            if (other.CompareTag(FinishTag))
            {
                player.GetHit();
            }
        }
    }
}