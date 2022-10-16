using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    
    [SerializeField] private Camera cam;
    
    public PlayerInputControl inputs;
    private InputAction move;

    private Animator anim; 
    
    private Vector3 moveDirection;
    private bool movementPressed;
    private Vector3 velocity;
    private float gravity = -9.8f;
    public float speed = 20f;
    public float jumpHeight = 20f;
    private bool grounded;
    private float groundCastDist = 5f;
    
    void Awake()
    {
        inputs = new PlayerInputControl();
        
        inputs.PlayerInteraction.Move.performed += context =>
        {
            moveDirection = context.ReadValue<Vector3>();
        };
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = transform;
        Transform cameraTransform = cam.transform;
        HandleMovement(playerTransform);

        Rotate(playerTransform, cameraTransform);
        
        Jump(playerTransform);

    }
    
    
    void HandleMovement(Transform playerTransform)
    {
        Vector3 movement = (playerTransform.right * moveDirection.x)
                           + (playerTransform.forward * moveDirection.z);
        
        // Vector3 movement = (playerTransform.forward * moveDirection.z); //non strafing
        
        controller.Move(movement * (speed * Time.deltaTime));
    }

    private void Jump(Transform playerTransform)
    {
        grounded = Physics.Raycast(playerTransform.position, Vector3.down, groundCastDist);
        
        velocity.y += gravity * Time.deltaTime; 
        if (inputs.PlayerInteraction.Jump.triggered && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight);
        } 
        controller.Move(velocity * Time.deltaTime);
    }
    
    private void Rotate(Transform playerTransform, Transform cameraTransform)
    {
        playerTransform.rotation = Quaternion.AngleAxis(cameraTransform.eulerAngles.y, Vector3.up);
        // playerTransform.rotation = Quaternion.AngleAxis(playerTransform.eulerAngles.y 
        //                                                 + (moveDirection.x *3), Vector3.up);
    }
    
    private void OnEnable()
    {
        inputs.PlayerInteraction.Enable();
    }

    private void OnDisable()
    {
       inputs.PlayerInteraction.Disable();
    }
}
