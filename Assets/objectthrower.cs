using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectthrower : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject throwable;
    
    [Header("Settings")] 
    // public int totalThrows;
    public float throwForce;
    public float throwUpwardForce;
    

    
    bool readyToThrow = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && readyToThrow)
        {
            Throw();
        }
    }

    void Throw()
    {
        // readyToThrow = false;
        GameObject projectile = Instantiate(throwable, attackPoint.position, cam.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;
        
        rb.AddForce(forceToAdd, ForceMode.Impulse);
        
        
    }
}

