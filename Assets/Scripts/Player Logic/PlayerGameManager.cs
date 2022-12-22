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
            //Change Scene
            Invoke("ChangeScene", 3f);
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("Scenes/PlayAgain");
    }

    public void EndAllGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Debug.Log("The game has successfully ended!");
            SceneManager.LoadScene("Scenes/EndGame");
        }
    }

    void Start()
    {
        
    }
}
