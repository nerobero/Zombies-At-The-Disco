using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    //interpolated from youtube 

    public Rigidbody rigid;

    public Collider collider;

    public Transform player;
    public Transform weaponContainer;
    public Transform cam;

    public float pickupRange;

    public float dropForce;

    public bool equipped = false;

    public WeaponScript weapon;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
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
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.Q) )
        {
            PickUp();
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
        transform.localScale = Vector3.one;
        ;

        weapon.enabled = true;
        playerController.weaponScript = weapon;
    }
    
}
