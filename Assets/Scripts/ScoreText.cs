using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private int newScore = 0;
    [SerializeField] private TextMeshProUGUI finalScore;
    
    void Start()
    {
        GlobalEventManager.OnEnemyKilled.AddListener(AddScore);
        GlobalEventManager.OnGameOver.AddListener(LogScore);
    }

    private void AddScore(Vector3 position, int score)
    {
        newScore += score;
        GetComponent<TextMeshProUGUI>().text = "Score " + newScore;
    }
    private void LogScore()
    {
        finalScore.text = "You final score: " + newScore;
    }
}
