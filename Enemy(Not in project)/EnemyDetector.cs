using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
                _playerController.isAttacking = true;
               // _playerController.SwitchStances();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.TryGetComponent(out Enemy enemy))
        {
            _playerController.isAttacking = false;
            //_playerController.SwitchStances();
        }
    }
}
