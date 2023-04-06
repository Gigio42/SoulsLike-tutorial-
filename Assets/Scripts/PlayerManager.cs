using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class PlayerManager : MonoBehaviour
    {
        InputHandler inputHandler;
        Animator animator;

        void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            animator = GetComponentInChildren<Animator>();
        }

        void Update()
        {
            inputHandler.isInteracting = animator.GetBool("isInteracting");
            inputHandler.rollflag = false;
            inputHandler.sprintFlag = false;
        }
    }
}