using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPusher : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _force;
    private Animator _animator;
    private RagdollController _ragdollController;
    public bool isAlive = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider>();
        _rb = GetComponent<Rigidbody>();
        _ragdollController = FindObjectOfType<RagdollController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bounce bounce))
        {
            Torque();
        }
    }

    private void Torque()
    {
        _rb.AddForce(transform.position + Vector3.down * -1 * _force + Vector3.forward * _force, ForceMode.Impulse);
        _animator.enabled = false;
        isAlive = false;
        _ragdollController.EnablePhysics();
        Destroy(gameObject, 5);
    }
}
