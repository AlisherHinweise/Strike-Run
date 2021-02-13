using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float _agroRadius;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private Transform player;

    private float _distance;
    public bool isFollowing = false;
    private EnemyPusher _enemyPusher;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        _enemyPusher = GetComponent<EnemyPusher>();
    }

    // Update is called once per frame
    private void Update()
    {
        _distance = Vector3.Distance(player.position, transform.position);
        if(_distance <= _agroRadius)
        {
            FollowingPlayer();
            LookingAtPlayer();
        }
        else
        {
            isFollowing = false;
        }
    }

    private void LookingAtPlayer()
    {
        transform.LookAt(player.position);
    }
    private void FollowingPlayer()
    {
        if (_enemyPusher.isAlive == true)
        {
            isFollowing = true;
            transform.position = Vector3.MoveTowards(transform.position, player.position, _moveSpeed * Time.deltaTime);
        }
    }
}
