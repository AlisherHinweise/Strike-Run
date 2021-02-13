using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Limb limb))
        {
            Enemy _enemy = collision.gameObject.GetComponentInParent<Enemy>();
            _enemy.HadCollision();
        }
    }
}
