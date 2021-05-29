using System;
using Core;
using Input;
using UnityEngine;

namespace Characters
{
    public class Enemy : Character
    {
        [SerializeField] private Player player;
        [SerializeField] private EnemyMovement movement;


        private void Update()
        {
            // Only update and move if the player is in Combat mode.
            if (player.GameState != GameState.Combat) return;
            
            // Follow the path laid out.
            movement.TravelToNextPoint();
        }
    }
}