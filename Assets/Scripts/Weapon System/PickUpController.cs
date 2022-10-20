using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    //from youtube 
    // public Weapon weaponScript;

    public Rigidbody rigid;

    public BoxCollider collider;

    public Transform player;
    public Transform weaponContainer;
    public Transform cam;

    public float pickupRange;

    public float dropForce;

    public bool equipped;

    // Start is called before the first frame update
    void Start()
    {
        if (!equipped)
        {
            // weaponScript.enabled = false;
            rigid.isKinematic = false;
            collider.isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickupRange && Input.GetKeyDown(KeyCode.E) )
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

        // weaponScript.enabled = true;
    }
    
}
