using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void PlayGame()
    {
        
        SceneManager.LoadSceneAsync("SampleScene");
        
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Start()
    {
        
    }
}
