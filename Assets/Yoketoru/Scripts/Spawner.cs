using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefab = default;
    [SerializeField]
    int spawnCount = 10;

    void Start()
    {
        for (int i = 0; i < spawnCount; i++) 
        {
            Instantiate(prefab);
        }
    }
}
