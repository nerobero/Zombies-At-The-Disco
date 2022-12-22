using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayMenu : MonoBehaviour
{

    private VisualElement root;

    private Button playButton;
    
    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        playButton = root.Q<Button>("PlayButton");
        
        //setting up the event handler for button: 
        playButton.RegisterCallback<ClickEvent>(ChangeScene);

    }

    private void ChangeScene(ClickEvent evt)
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    
}
