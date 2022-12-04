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
            SceneManager.LoadSceneAsync("PlayAgain");

        }
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
