using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public Animator playerAnimator; 

    public float speed = 6f;

    public float gravity = 10f;
    public float jumpForce = 2f;
    public float sprintSpeed = 18f;

    public float smoothTurnTime = 0.1f;
    float turnSmoothVelocity;
    
    private Vector3 moveDir = Vector3.zero;

    private bool sprinting = false;

    // Update is called once per frame
    void Update()
    {
        float currentVerticalAccel = moveDir.y + 0f;
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
            smoothTurnTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        moveDir *= direction.magnitude;

        if (moveDir.magnitude >= 0.1f)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprinting = true;
            playerAnimator.SetBool("isRunning", true);
        }
        else
        { 
            sprinting = false;
            playerAnimator.SetBool("isRunning", false);
        }
        
        if (sprinting)
        {
            moveDir *= sprintSpeed;
        }
        else
        {
            moveDir *= speed;
        }

        moveDir.y = currentVerticalAccel;


        if (Input.GetButtonDown("Jump"))
        {
            moveDir.y = jumpForce;
        }

        moveDir.y -= gravity * Time.deltaTime;
        
       
        controller.Move(moveDir * Time.deltaTime);

    }
}
