using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _spawnPoint;

    void Awake()
    {
        _spawnPoint = GetComponentInChildren<SpawnPoint>().transform;
        Spawn();
    }

    private void Spawn()
    {
        Instantiate(_player, _spawnPoint.position, Quaternion.identity, null);
    }
}
