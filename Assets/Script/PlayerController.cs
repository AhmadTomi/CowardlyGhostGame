using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    public static float velocity=0;
    private CharacterController characterController;
    private Vector3 direction;

    private int desiredLane = 1;
    public float laneDistance = 4;
    public float jumpForce = 10;
    public float gravity = -20;

    public Transform Destroypoint;

    void Start()
    {
        
        characterController = GetComponent<CharacterController>();
        velocity = 10;

    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;
        direction.z = velocity;
        
        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = 0;
                Jump();
            }
            
        }
        else {
            direction.y += gravity * Time.deltaTime;
        }




        if (Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            characterController.Move(moveDir);
        else
            characterController.Move(diff);

        //transform.position = Vector3.Lerp(transform.position, targetPosition,80*Time.deltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;
        characterController.Move(direction * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
            FindObjectOfType<AudioManager>().StopSound("BGM");
        }
    }
}
