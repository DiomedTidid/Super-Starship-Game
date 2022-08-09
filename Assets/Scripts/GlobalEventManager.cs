using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent<Vector3, int> OnEnemyKilled  = new UnityEvent<Vector3, int>();

    
    public static void SendEnemyKilled(Vector3 position, int score)
    {
        OnEnemyKilled.Invoke(position, score);
    }
}