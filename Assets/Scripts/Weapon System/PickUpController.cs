using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpController : MonoBehaviour
{
    //interpolated from youtube 

    public Rigidbody rigid;

    public Collider collider;

    public Transform player;
    public Transform weaponContainer;

    public float pickupRange;

    public float dropForce;

    public bool equipped = false;

    public WeaponScript weapon;
    public PlayerController playerController;
    public PlayerInputControl playerinputs;

    // Start is called before the first frame update
    void Start()
    {
        //just the initial configs for equipping
        if (!equipped)
        {
            
            weapon.enabled = false;
            rigid.isKinematic = false;
            collider.isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (equipped && Input.GetKeyDown(KeyCode.E))
        {
            Drop();
        }
        else
        {
            Vector3 distanceToPlayer = player.position - transform.position;
            if (!equipped && distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }
        

        
    }

    void PickUp()
    {
        equipped = true;
        rigid.isKinematic = true;
        collider.isTrigger = true;
        
        transform.SetParent(weaponContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        // transform.localScale = Vector3.one;
        ;

        weapon.enabled = true;
        playerController.weaponScript = weapon;
    }

    void Drop()
    {
        equipped = false;
        rigid.isKinematic = false;
        collider.isTrigger = false;
        
        transform.SetParent(null);

        rigid.velocity = player.GetComponent<Rigidbody>().velocity;
        // rigid.AddForce(dropForce, ForceMode.Impulse);

        playerController.weaponScript = playerController.fist;
        weapon.enabled = false;
    }
    
}
