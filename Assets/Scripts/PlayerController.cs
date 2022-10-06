using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl inputs;
    private InputAction move;

    private Animator anim; 
    
    private Vector2 moveDirection;
    private bool movementPressed;
    private bool runPressed;

    int isWalkingHash; //by default the player character walks
    int isRunningHash; //but with Left shift pressed, you can run

    void Awake()
    {
        inputs = new PlayerInputControl();

        inputs.PlayerInteraction.Move.performed += context =>
        {
            moveDirection = context.ReadValue<Vector2>();
            movementPressed = moveDirection.x != 0 || moveDirection.y != 0;
        };
        inputs.PlayerInteraction.Run.performed += context => runPressed
            = context.ReadValueAsButton();
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        //setting the ID references:
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleRotation()
    {
        Vector3 currentPos = transform.position;

        Vector3 newPos = new Vector3(moveDirection.x, 0, moveDirection.y);

        Vector3 posToLookAt = currentPos + newPos;
        
        transform.LookAt(posToLookAt);
    }
    void HandleMovement()
    {
        bool isRunning = anim.GetBool(isRunningHash);
        bool isWalking = anim.GetBool(isWalkingHash);

        // start walking if movement pressed is true and
        // not already walking
        if (movementPressed && !isWalking)
        {
            anim.SetBool(isWalkingHash, true);
        }
        
        // stop walking if movement pressed is false
        // and not already walking
        if (!movementPressed && isWalking)
        {
            anim.SetBool(isWalkingHash, false);
        }

        // start running if movement pressed and run pressed are true
        // and not already running
        if ((movementPressed && runPressed) && !isRunning)
        {
            anim.SetBool(isRunningHash, true);
        }

        // stop running if movement pressed or run pressed is false
        // and currently running
        if ((!movementPressed || !runPressed) && isRunning)
        {
            anim.SetBool(isRunningHash, false);
        }
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
