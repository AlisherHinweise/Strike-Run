using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private float _sawSpeed;
    [SerializeField] private float _sawDistance;
    [SerializeField] private bool _parallel;
    private Vector3 _spawnPostion;
    private Vector3 _sawDirection;
    private Rigidbody _rb;

    private void Start()
    {
        _spawnPostion = transform.position;
        if (_parallel == true) _sawDirection = Vector3.forward;
        else if (_parallel == false) _sawDirection = Vector3.right;
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(routine: Mover());
    }

    private IEnumerator Mover()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + _sawDirection, _sawSpeed * Time.deltaTime);
            if(_parallel == true) 
            {
                if (transform.position.z > _spawnPostion.z + _sawDistance) _sawDirection = Vector3.back;
                else if (transform.position.z < _spawnPostion.z - _sawDistance) _sawDirection = Vector3.forward;
            }
            if (_parallel == false)
            {
                if (transform.position.x > _spawnPostion.x + _sawDistance) _sawDirection = Vector3.left;
                else if (transform.position.x < _spawnPostion.x - _sawDistance) _sawDirection = Vector3.right;
            }
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Enemy _enemy = collision.gameObject.GetComponentInParent<Enemy>();
            _enemy.HadCollisionWithObstacle();
        }
    }
}
