using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    
    public PlayerInputControl inputs;
    private InputAction move;

    private Animator anim; 
    
    private Vector3 moveDirection;
    private bool movementPressed;
    private Vector3 velocity;
    private float gravity = -9.8f;
    public float speed = 5f;
    public float jumpHeight = 2f;

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
        HandleMovement();

        Jump();

    }
    
    
    void HandleMovement()
    {
        Transform playerTransform = transform; 
        Vector3 movement = (playerTransform.right * moveDirection.x)
                           + (playerTransform.forward * moveDirection.z);
        controller.Move(movement * (speed * Time.deltaTime));
    }

    private void Jump()
    {
        velocity.y += gravity * Time.deltaTime; 
        if (inputs.PlayerInteraction.Jump.triggered)
        {
            velocity.y = Mathf.Sqrt(jumpHeight);
        } 
        controller.Move(velocity * Time.deltaTime);
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
