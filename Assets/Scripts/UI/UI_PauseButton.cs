using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PauseButton : MonoBehaviour
{
    
    void Start()
    {
        GlobalEventManager.OnGameOver.AddListener(DisablePause);
    }

    private void DisablePause()
    {
        gameObject.SetActive(false);
    }
}
