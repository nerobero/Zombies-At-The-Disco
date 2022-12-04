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
            SceneManager.LoadSceneAsync(2);
            Debug.Log("Respawning in 3 seconds...");
            Invoke("Restart", 3f);
        }
    }

    void Restart()
    {
        SceneManager.LoadSceneAsync(1);
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
}
