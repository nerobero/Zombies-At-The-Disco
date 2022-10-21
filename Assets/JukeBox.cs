using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeBox : MonoBehaviour
{
    
    //interpolated from youtube 

    public Transform player;
    
    public float pickupRange;

    public JukeBoxGUI gui;
    
    public PlayerController playerController;


    private void Start()
    {
        gui.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E) )
        {
            PickUp();
        }
    }
    void PickUp()
    {
        gui.enabled = true;
        gui.showPanel();
        Debug.Log("OpenedJukebox");

    }
}
