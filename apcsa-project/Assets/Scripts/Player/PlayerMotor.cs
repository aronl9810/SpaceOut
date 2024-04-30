using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 playerVelocity;
    public ViewBobbing bobbing;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;
    public bool sprinting = false;
    public GameObject footsteps;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // footsteps.SetActive(false);
        isGrounded = controller.isGrounded;
        if(sprinting){
            if(Input.GetKey(KeyCode.LeftShift)){
                speed = 10f;
                bobbing.spintEffect();
            } else {
                speed = 6.5f;
                sprinting = false;
                bobbing.afterSprintEffect();
            }
        }
    }

// Basically this recieves input from InputManager.cs and apply them to our character controller
    public void ProcessMove(Vector2 input){
        Vector3 defaultposition = new Vector3(0,0,0);
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0){
            playerVelocity.y = -2f;
            if(moveDirection == defaultposition){
                footsteps.SetActive(false);
            } else {
                footsteps.SetActive(true);
            }
        } else {
            footsteps.SetActive(false);
        }
        controller.Move(playerVelocity * Time.deltaTime);
        // Debug.Log(moveDirection);
    }
    
    public void Jump(){
        if(isGrounded){
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Sprint(){
        sprinting = !sprinting;
    }

    public bool getSprint(){
        return sprinting;
    }


}