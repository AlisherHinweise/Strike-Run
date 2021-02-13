using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private EnemyFollow _enemyFollow;

    private void Start()
    {
        _enemyFollow = GetComponent<EnemyFollow>();
        anim.SetBool("isRunning", false);
    }

    private void Update()
    {
        if(_enemyFollow.isFollowing == false)
        {
            anim.SetBool("isRunning", false);
        }
        else if(_enemyFollow.isFollowing == true)
        {
            anim.SetBool("isRunning", true);
        }
    }
}
