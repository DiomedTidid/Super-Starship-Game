using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent<Vector3, int> OnEnemyKilled  = new();
    public static UnityEvent OnGameOver = new();
    private static bool isGameOver = false;

    private void Awake()
    {
        isGameOver = false;
    }
    private void Update()
    {
       if (isGameOver) StartCoroutine(EndGameTimer());
    }

    public static void SendEnemyKilled(Vector3 position, int score)
    {
       OnEnemyKilled.Invoke(position, score);
    }

    public static void SendGameOver()
    {
        isGameOver = true;
    }

    public static IEnumerator EndGameTimer()
    {
        
        yield return new WaitForSeconds(1);
       OnGameOver.Invoke();

    }

}
