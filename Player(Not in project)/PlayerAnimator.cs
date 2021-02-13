using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    private PlayerController1 playerMover;

    private void Start()
    {
        playerMover = FindObjectOfType<PlayerController1>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimationSwitch();
    }

    private void AnimationSwitch()
    {
        if (playerMover.rb.velocity != new Vector3(0, 0, 0) && playerMover.isAttacking != true)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (playerMover.isAttacking == true)
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }
}
