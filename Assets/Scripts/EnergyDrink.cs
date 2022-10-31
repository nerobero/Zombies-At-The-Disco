using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : MonoBehaviour
{
    
    //interpolated from youtube 

    public Transform player;
    
    public float pickupRange;
    
    public PlayerController playerController;



    // Update is called once per frame
    void Update()
    {
        //if the object is within the pickup range and the player presses E key,
        //the player character picks up the energy drink object from the map
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E) )
        {
            PickUp();
        }
    }
    
    // Start is called before the first frame update
    void PickUp()
    {
        //when the player picks up the energy drink, 
        //the healing effect takes place instantaneously
        playerController.animator.SetBool("isDrink", true);
        
        Debug.Log("Drank energy drink");
        playerController.PlayerHpSystem.EnergyDrink(30f);
        Destroy(gameObject);
        
    }
}
