using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameManager : MonoBehaviour
{
    private bool gameEnded = false;

    public void EndGameRound()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Debug.Log("The player has died!");
            //restart game here
            Debug.Log("Respawning in 3 seconds...");
            GameObject.Find("PlayAgainScreen").GetComponent<Canvas>().enabled = true;
            Invoke("Restart", 3f);
        }
    }

    void Restart()
    {
        GameObject.Find("PlayAgainScreen").GetComponent<Canvas>().enabled = false;
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void EndAllGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Debug.Log("The game has successfully ended!");
            SceneManager.LoadSceneAsync("EndGame");
        }
    }

    void Start()
    {
        GameObject.Find("PlayAgainScreen").GetComponent<Canvas>().enabled = false;
    }
}
