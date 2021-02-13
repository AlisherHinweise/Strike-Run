using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public List<Rigidbody> _ragdolElements;
    private Animator _animator;

    private void Start()
    {
        DisablePhysics();
        _animator = GetComponentInParent<Animator>();
    }

    public void EnablePhysics()
    {
        _animator.enabled = false;
        for (int i = 0; i < _ragdolElements.Count; i++)
        {
            _ragdolElements[i].isKinematic = false;
        }
    }
    
    private void DisablePhysics()
    {
        for (int i = 0; i < _ragdolElements.Count; i++)
        {
            _ragdolElements[i].isKinematic = true;
        }
    }
}
