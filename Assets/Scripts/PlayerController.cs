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
    public float runSpeed = 60f;
    public float jumpHeight = 20f;
    private bool grounded;
    private float groundCastDist = 5f;
    private bool isRunning;
    
    void Awake()
    {
        inputs = new PlayerInputControl();
        
        inputs.PlayerInteraction.Move.performed += context =>
        {
            moveDirection = context.ReadValue<Vector3>();
        };

        inputs.PlayerInteraction.Run.performed += Run;
        inputs.PlayerInteraction.EndRun.performed += RunEnd;
        NonMovementControls cont = new GameObject().AddComponent<NonMovementControls>();
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

        HandleRun(playerTransform);
        
        Rotate(playerTransform, cameraTransform);
        
        Jump(playerTransform);
        
    }

    private void HandleRun(Transform playerTransform)
    {
        Vector3 movement = (playerTransform.right * moveDirection.x)
                           + (playerTransform.forward * moveDirection.z);
        
        if (isRunning)
        {
            controller.Move(movement * (runSpeed * Time.deltaTime));
        }
        
        if (!isRunning)
        {
            controller.Move(movement * (speed * Time.deltaTime));
        }
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
    
    private void Run(InputAction.CallbackContext obj)
    {
        isRunning = true;
    }

    private void RunEnd(InputAction.CallbackContext obj)
    {
        isRunning = false;
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
