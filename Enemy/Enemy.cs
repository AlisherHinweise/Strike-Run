using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;

    private ProgressBar _progressBar;
    private Animator _enemyAnimator;
    private Transform _playerTransform;
    private Rigidbody[] _limbs;
    private CapsuleCollider _collider;
    private Count _coinCounter;
    private NavMeshAgent _agent;
    public Rigidbody _rb;

    private int _deadEnemy;
    private bool _isAlive = true;
    private float _enemyMoveSpeed;
    private float _enemyAttackRadius;
    private float _distance;
    private float _force;

    private void Start()
    {
        _enemyAttackRadius = GameplaySettings.enemyAttackRadius;
        _enemyMoveSpeed = GameplaySettings.enemyMoveSpeed;
        _force = GameplaySettings.force;

        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _enemyMoveSpeed;
        _coinCounter = FindObjectOfType<Count>();
        _progressBar = FindObjectOfType<ProgressBar>();
        _collider = GetComponent<CapsuleCollider>();
        _rb = GetComponent<Rigidbody>();
        _enemyAnimator = GetComponent<Animator>();
        _playerTransform = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        _limbs = GetComponentsInChildren<Rigidbody>();

        RefreshEnemy();
    }

    private void Update()
    {
        FollowingPlayer();
    }

    public void HadCollision()
    {
        ActivateRagdoll();
        _enemyAnimator.SetBool("isRunning", false);
        if(_isAlive == true)
        {
            _isAlive = false;
            _progressBar.EnemyCounter();
            _coinCounter.AddCoins();
        }
        Destroy(gameObject, 3);
    }

    public void HadCollisionWithObstacle()
    {
        Destroy(Instantiate(_deathEffect.gameObject, transform.position, Quaternion.identity, null), 16);
        _agent.enabled = false;
        if (_isAlive == true)
        {
            _isAlive = false;
            _progressBar.EnemyCounter();
            _coinCounter.AddCoins();
        }
        Destroy(gameObject);
    }

    private void ActivateRagdoll()
    {
        Destroy(_collider);
        _enemyAnimator.enabled = false;
        _agent.enabled = false;
        foreach (var limb in _limbs)
        {
            limb.isKinematic = false;
            limb.useGravity = true;
            limb.AddForce(-transform.forward * _force);
        }
    }

    private void RefreshEnemy()
    {
        _agent.enabled = true;
        foreach (var limb in _limbs)
        {
            limb.useGravity = false;
        }
    }

    private void FollowingPlayer()
    {
        _distance = Vector3.Distance(_playerTransform.position, transform.position);
        Vector3 _player = new Vector3(_playerTransform.position.x, 0, _playerTransform.position.z);
        if (_distance <= _enemyAttackRadius && _isAlive == true)
        {
            transform.LookAt(_player);
            _agent.SetDestination(_playerTransform.position);
            _enemyAnimator.SetBool("isRunning", true);
        }
        else if(_distance > _enemyAttackRadius && _isAlive == true)
        {
            _agent.SetDestination(transform.position);
            _enemyAnimator.SetBool("isRunning", false);
        }
    }
}
