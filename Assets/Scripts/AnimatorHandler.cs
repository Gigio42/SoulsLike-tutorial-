using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class AnimatorHandler : MonoBehaviour
    {
        public PlayerManager playerManager;
        public Animator animator;
        InputHandler inputHandler;
        PlayerLocomotion playerLocomotion;
        int vertical;
        int horizontal;
        public bool canRotate;

        public void Initialize()
        {
            playerManager = GetComponentInParent<PlayerManager>();
            animator = GetComponent<Animator>();
            inputHandler = GetComponentInParent<InputHandler>();
            playerLocomotion = GetComponentInParent<PlayerLocomotion>();
            vertical = Animator.StringToHash("Vertical");
            horizontal = Animator.StringToHash("Horizontal");
        }

        public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement, bool isSprinting)
        {
            #region Vertical
            float v = 0;

            if (verticalMovement > 0 && verticalMovement < 0.55f)
            {
                v = 0.5f;
            }
            else if (verticalMovement > 0.55f)
            {
                v = 1;
            }
            else if (verticalMovement < 0 && verticalMovement > -0.55f)
            {
                v = -0.5f;
            }
            else if (verticalMovement < -0.55f)
            {
                v = -1;
            }
            else
            {
                v = 0;
            }
            #endregion

            #region Horizontal
            float h = 0;

            if (verticalMovement > 0 && verticalMovement < 0.55f)
            {
                h = 0.5f;
            }
            else if (verticalMovement > 0.55f)
            {
                h = 1;
            }
            else if (verticalMovement < 0 && verticalMovement > -0.55f)
            {
                h = -0.5f;
            }
            else if (verticalMovement < -0.55f)
            {
                h = -1;
            }
            else
            {
                h = 0;
            }
            #endregion

            if(isSprinting)
            {
                v = 2;
                h = horizontalMovement;
            }

            animator.SetFloat(vertical, v, 0.1f, Time.deltaTime);
            animator.SetFloat(horizontal, h, 0.1f, Time.deltaTime);
        }

        public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
        {
            animator.applyRootMotion = isInteracting;
            animator.SetBool("isInteracting", isInteracting);
            animator.CrossFade(targetAnimation, 0.2f);
        }

        public void CanRotate()
        {
            canRotate = true;
        }

        public void StopRotation()
        {
            canRotate = false;
        }

        private void OnAnimatorMove() 
        {
            if (playerManager.isInteracting == false) return;

            float delta = Time.deltaTime;
            playerLocomotion.rigidbody.drag = 0;
            Vector3 deltaPosition = animator.deltaPosition;
            deltaPosition.y = 0;
            Vector3 velocity = deltaPosition / delta;
            playerLocomotion.rigidbody.velocity = velocity;
        }
    }
}