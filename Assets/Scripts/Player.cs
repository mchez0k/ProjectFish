using System.Collections;
using System.Collections.Generic;
using ProjectFish.Movement;
using UnityEngine;

namespace ProjectFish.Player
{
    public class Player : MonoBehaviour
    {
        private IInputSource moveInput;
        private IMovement playerMovement;

        public void Awake()
        {
            moveInput = GetComponent<KeyboardInput>();
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            playerMovement.Move(moveInput.GetMovementInput(), moveInput.GetRunInput());
            playerMovement.Rotate(moveInput.GetLookInput());
            playerMovement.ApplyGravity(moveInput.GetJumpInput());
        }
    }
}

