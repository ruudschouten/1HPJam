using System;
using Core;
using Events;
using UnityEngine;

namespace Characters
{
    public class Movement : MonoBehaviour
    {
        
        [SerializeField] private KeyCode upCode = KeyCode.W;
        [SerializeField] private KeyCode leftCode = KeyCode.A;
        [SerializeField] private KeyCode rightCode = KeyCode.S;
        [SerializeField] private KeyCode downCode = KeyCode.D;
        
        [SerializeField] private float movementSpeed;
        [SerializeField] private MonoRenderer character;

        [SerializeField] private MovementEvent onMove;
        [SerializeField] private FloatEvent onJump;

        private void Update()
        {
            // TODO: Movement
            if (UnityEngine.Input.GetKey(upCode))
            {

            }
           
            if (UnityEngine.Input.GetKey(leftCode))
            {

            }
            
            if (UnityEngine.Input.GetKey(rightCode))
            {

            }
            
            if (UnityEngine.Input.GetKey(downCode))
            {

            }
        }
    }
}