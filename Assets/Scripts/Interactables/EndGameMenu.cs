using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndGameMenu : MonoBehaviour
{

    private VisualElement root;

    private Button restartGameButton;
    private Button quitGameButton;
    
    // Start is called before the first frame update
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        restartGameButton = root.Q<Button>("RestartGame");
        quitGameButton = root.Q<Button>("QuitGame");
        
        //setting up the event handler for buttons: 
        restartGameButton.RegisterCallback<ClickEvent>(RestartGame);
        
        quitGameButton.RegisterCallback<ClickEvent>(QuitGame);
    }

    private void RestartGame(ClickEvent evt)
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    private void QuitGame(ClickEvent evt)
    {
        Application.Quit();
    }
}
