using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject playerRoot;
    Rigidbody playerRb;

    
    enum AnimeState
    {
        Idle,
        Run,
        Jump,
    }
    AnimeState aState;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (playerRoot == null)
        {
            playerRoot = transform.parent.gameObject;
        }

        playerRb = playerRoot.GetComponent<Rigidbody>();

        
    }

    
    void Update()
    {
        Vector3 playerVel = playerRb.velocity;
        Vector3 horizontalVel = new Vector3(playerVel.x, 0, playerVel.z);

        bool onGround = playerRoot.GetComponent<PlayerController3D>().onGround;

        if(onGround)
        {
            if(horizontalVel.magnitude < 0.01f)
            {
                aState = AnimeState.Idle;
            }
            else
            {
                aState = AnimeState.Run;
            }
        }
        else
        {
            aState = AnimeState.Jump;
        }



        //
        switch (aState)
        {
            case AnimeState.Idle:
                animator.SetBool("Run", false);
                animator.SetBool("Jump", false);
                Debug.Log("Idle");
                break;

            case AnimeState.Run:
                animator.SetBool("Run", true);
                animator.SetBool("Jump", false);
                Debug.Log("Run");
                break;

            case AnimeState.Jump:
                animator.SetBool("Run", false);
                animator.SetBool("Jump", true);
                Debug.Log("Jump");
                break;

        }

    }
}
