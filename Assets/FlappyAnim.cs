using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class FlappyAnim : MonoBehaviour
{
    StartMenu startMenu;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

         public void Jump()
        {
            animator.SetTrigger("Jump");
        }
        public void UpdateYVelocity(float yVelocity)
        {
            animator.SetFloat("Y_Velocity", yVelocity);
        }

}
