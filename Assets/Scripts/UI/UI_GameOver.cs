using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GameOver : MonoBehaviour
{
    private void Start()
    {
        GlobalEventManager.OnGameOver.AddListener(ActivateWindow) ;
        gameObject.SetActive(false);
    }

   public void ActivateWindow()
    {
        gameObject.SetActive(true);

    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    
}
