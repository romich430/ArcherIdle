using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public Enemy enemy;
    
    public void SpawnEnemy()
    {
        Instantiate(enemy, new Vector3(transform.position.x, Random.Range(-3.5f, 1), 0), Quaternion.identity);
    }
}
