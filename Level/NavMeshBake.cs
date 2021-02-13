using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBake : MonoBehaviour
{
    public void Bake()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
