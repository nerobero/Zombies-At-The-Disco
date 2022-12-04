using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameManager : MonoBehaviour
{
    private bool gameEnded = false;
    public float respawnTime = 2f;
    
    public void EndGameRound()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Debug.Log("The player has died!");
            //restart game here
            RestartRound();
        }
    }

    void RestartRound()
    {
        gameEnded = false;
        SceneManager.LoadScene("PlayAgain");
    }

    public void EndAllGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Debug.Log("The game has successfully ended!");
            SceneManager.LoadScene("EndGame");
        }
    }
}
