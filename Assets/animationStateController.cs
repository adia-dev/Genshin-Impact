using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool("isRunning");
     bool isWalking = animator.GetBool(isWalkingHash);
    bool forwardPressed = Input.GetKey("z");
    bool runPressed = Input.GetKey("left shift")

     if (!isWalking && forwardPressed){
            animator.SetBool("isWalking", true);
        }
        if (isWalking && !forwardPressed){
            animator.SetBool("isWalking", false);
        }

        if (isRunning && runPressed){
            animator.SetBool("isRunning", true);
        }
        if (!isRunning && !runPressed){
            animator.SetBool("isRunning", false);
        }
    }
}
