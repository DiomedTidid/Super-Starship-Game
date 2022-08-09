using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private int newScore = 0;
    
    void Start()
    {
        GlobalEventManager.OnEnemyKilled.AddListener(AddScore);
    }

    private void AddScore(Vector3 position, int score)
    {
        newScore += score;
        GetComponent<TextMeshProUGUI>().text = "Score " + newScore;
    }
}
