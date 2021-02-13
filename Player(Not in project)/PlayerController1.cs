using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    //[SerializeField] private Joystick _joystick;
    public Rigidbody rb;
    [SerializeField] private float _speed;
    [SerializeField] private SphereCollider _attackRadius;
    [SerializeField] private float _spinSpeed;
    public bool isAttacking = false;
    Quaternion rotation;
    Vector3 playerViewAt;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //_joystick = FindObjectOfType<Joystick>();
        _attackRadius = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        Move();
        if (isAttacking == true) 
        { 
            RotateIsAttacking(); 
        }
        else
        {
            RotateNotAttacking();
        }
    }

    private void Move()
    {
        //rb.velocity = new Vector3(_joystick.Horizontal * _speed, 0, _joystick.Vertical * _speed);
    }

    private void RotateIsAttacking()
    {
        transform.Rotate(0, _spinSpeed * Time.deltaTime * -1, 0);
    }

    private void RotateNotAttacking()
    {
        if (rb.velocity != new Vector3(0, 0, 0))
        {
            rotation = Quaternion.LookRotation(rb.velocity);
        }
        transform.rotation = rotation;
    }
}
