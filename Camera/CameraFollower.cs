using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private PlayerController _player;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        CameraFollow();
    }

    // Update is called once per frame
    void CameraFollow()
    {
        transform.position = _player.transform.position + offset;
    }
}
