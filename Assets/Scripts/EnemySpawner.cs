using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
   
    [SerializeField] private float enemySpawnPerSecond = 0.5f;
    [SerializeField] private GameObject[] enemyPrefabs;
     

    void Awake()
    {
        
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    }

   
    public void SpawnEnemy()
    {
        int ndx = Random.Range(0, enemyPrefabs.Length);
       
       GameObject go = Instantiate<GameObject>(enemyPrefabs[ndx]);

        Vector3 pos = Vector3.zero;
        float xBound = 27;
        float yBound = 44;
        pos.x = Random.Range(-xBound, xBound);
        pos.y = yBound;
        go.transform.position = pos;

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    

   
}
