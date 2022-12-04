<<<<<<< Updated upstream
=======
<<<<<<< HEAD
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class projectile : MonoBehaviour
// {
//     [Header("References")]
//     public Transform cam;
//     public Transform attackPoint;
//     public Rigidbody rigid;
//     
//     [Header("Settings")] 
//     public float throwForce;
//     public float throwUpwardForce;
//     
//
//     
//     private bool equipped = false;
//     
//     
//     // Start is called before the first frame update
//     void Start()
//     {
//         
//     }
//     
//     void PickUp()
//     {
//         equipped = true;
//         rigid.isKinematic = true;
//         // collider.isTrigger = true;
//         
//         transform.SetParent(attackPoint);
//         transform.localPosition = Vector3.zero;
//         transform.localRotation = Quaternion.Euler(Vector3.zero);
//         // transform.localScale = Vector3.one;
//         ;
//
//         readyToThrow = true;
//         playerController.weaponScript = weapon;
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         
//     }
// }
=======
>>>>>>> Stashed changes
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Rigidbody rb;

    private bool targetHit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (!targetHit)
        {
            targetHit = true;
            Destroy(gameObject);
        }
    }
}
<<<<<<< Updated upstream
=======
>>>>>>> 0295ca35ba3e68ce4a31298fd6f3fb29f77ca3c8
>>>>>>> Stashed changes
