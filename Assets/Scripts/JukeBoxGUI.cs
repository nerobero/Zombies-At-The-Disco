using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JukeBoxGUI : MonoBehaviour
{
    public Image panel;
    
    // Start is called before the first frame update
    void Start()
    {
        panel.enabled = false;
    }

    public void showPanel()
    {
        panel.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.enabled = false;
            enabled = false;
        }
    }
}
