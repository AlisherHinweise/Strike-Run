using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSarousel : MonoBehaviour
{
    [SerializeField] private float _mainSawSpinSpeed;
    [SerializeField] private bool _clockWise;

    void Start()
    {
        StartCoroutine(routine: RotatingMainSaw());
    }

    private IEnumerator RotatingMainSaw()
    {
        while (true)
        {
            if (_clockWise == true) transform.Rotate(0, _mainSawSpinSpeed * Time.deltaTime, 0);
            else if (_clockWise == false) transform.Rotate(0, -_mainSawSpinSpeed * Time.deltaTime, 0);
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
