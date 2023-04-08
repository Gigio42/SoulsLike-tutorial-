using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class PlayerManager : MonoBehaviour
    {
        InputHandler inputHandler;
        Animator animator;
        CameraHandler cameraHandler;
        PlayerLocomotion playerLocomotion;

        public bool isInteracting;

        [Header("Player Flags")]
        public bool isSprinting;
        public bool isInAir;
        public bool isGrounded;

        private void Awake() 
        {
            cameraHandler = CameraHandler.singleton;
        }

        void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            animator = GetComponentInChildren<Animator>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
        }

        void Update()
        {
            float delta = Time.deltaTime;

            isInteracting = animator.GetBool("isInteracting");

            inputHandler.TickInput(delta);
            playerLocomotion.HandleMovment(delta);
            playerLocomotion.HandleRollingAndSprinting(delta);
            playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);

        }

        private void FixedUpdate() 
        {
            float delta = Time.fixedDeltaTime;

            if (cameraHandler != null)
            {
                cameraHandler.FollowTarget(delta);
                cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
            }
        }

        private void LateUpdate() 
        {
            inputHandler.rollflag = false;
            inputHandler.sprintFlag = false;
            isSprinting = inputHandler.b_Input;

            if (isInAir)
            {
                playerLocomotion.inAirTimer = playerLocomotion.inAirTimer + Time.deltaTime;
            }
        }

        
    }
}