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
