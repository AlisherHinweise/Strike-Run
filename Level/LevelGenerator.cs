using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private NavMeshBake _navMesh;
    [SerializeField] private Transform _player;
    [SerializeField] private Platform[] platformes;
    [SerializeField] private Platform _startPlatform;
    [SerializeField] private Platform[] bridges;
    [SerializeField] private Platform _finishPlatform;
    [SerializeField] private int _platformesCount;

    private List<Platform> spawnedPlatformes = new List<Platform>();

    private void Awake()
    {
        _platformesCount = _platformesCount * 2;
        spawnedPlatformes.Add(_startPlatform);
        int i = 0;
        while(i < _platformesCount)
        {
            Spawn();
            i++;
        }
        _navMesh.Bake();
    }

    private void Spawn()
    {
        Platform newPlatform;
        if (spawnedPlatformes.Count % 2 == 0 && spawnedPlatformes.Count != _platformesCount)
        {
            newPlatform = Instantiate(platformes[Random.Range(0, platformes.Length)]);
        }
        else if(spawnedPlatformes.Count == _platformesCount)
        {
            newPlatform = Instantiate(_finishPlatform);
        }
        else
        {
            newPlatform = Instantiate(bridges[Random.Range(0, bridges.Length)]);
        }
        newPlatform.transform.position = spawnedPlatformes[spawnedPlatformes.Count - 1].end.position - newPlatform.begin.localPosition;
        spawnedPlatformes.Add(newPlatform);
    }
}
