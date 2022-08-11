using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsDrop : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUpsPrefabs;
    
    private void Awake()
    {
        GlobalEventManager.OnEnemyKilled.AddListener(optionForDrop);
    }


    private void optionForDrop(Vector3 position, int score)
    {
        float rnd = Random.Range(0, 101);
        if (rnd <= 30) PowerUpDrop(position, score);
    }

    private void PowerUpDrop(Vector3 position, int score)
    {
        int index = Random.Range(0, powerUpsPrefabs.Length);
        GameObject go = Instantiate<GameObject>(powerUpsPrefabs[index]);
        go.transform.position = position;
    }
}
