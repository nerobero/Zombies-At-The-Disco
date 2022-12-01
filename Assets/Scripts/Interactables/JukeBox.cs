using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JukeBox : MonoBehaviour
{
    
    //interpolated from youtube 

    public Transform player;
    
    public float pickupRange;

    public JukeBoxGUI gui;
    
    public PlayerInputControl playerinputs;

    //changing music
    private InputAction interact;

    [SerializeField] private AudioClip[] songlist;
    private AudioSource sound;

    private void Start()
    {
        gui.enabled = false;
        sound = GetComponents<AudioSource>()[0];
        sound.volume = 0.5f;
        sound.spatialBlend = 1f;
        sound.maxDistance = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickupRange && playerinputs.PlayerInteraction.Interact.triggered )
        {
            ChangeMusic();
        }
    }
    void ChangeMusic()
    {
        gui.enabled = true;
        gui.showPanel();
        Debug.Log("OpenedJukebox");

    }

    public AudioClip GetSong(int index)
    {
        return songlist[index];
    }
}
