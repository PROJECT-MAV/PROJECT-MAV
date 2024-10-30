using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController charController;
    private CharacterAnimations playerAnimations;

    public float movement_Speed = 3f;
    public float gravity = 9.8f;
    public float rotation_Speed = 0.15f;
    public float rotateDegreesPerSecond = 100f;

    // 1st function that is called
    void Awake()
    {
        charController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
        // Rotate();
        AnimateWalk();
    }

    void Move() {
        if (Input.GetAxis("Horizontal") > 0) {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime; // update는 1초에 60번 사용되므로 움직임을 부드럽게 하기 위해 아주 작은 값, deltaTime을 곱한다

            charController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }

        else if (Input.GetAxis("Horizontal") < 0) {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime);
            
        } else { // no input
            charController.Move(Vector3.zero);
        }
    }
    
    void Rotate() {
        Vector3 rotation_Direction = Vector3.zero;

        if (Input.GetAxis("Horizontal") < 0) {
            rotation_Direction = transform.TransformDirection(Vector3.left);
        }

        if (Input.GetAxis("Horizontal") > 0) {
            rotation_Direction = transform.TransformDirection(Vector3.right);
        }

        if(rotation_Direction != Vector3.zero) {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.LookRotation(rotation_Direction),
                rotateDegreesPerSecond * Time.deltaTime);
        }
    }

    void AnimateWalk() {
        if (charController.velocity.sqrMagnitude != 0f) {
            playerAnimations.Walk(true);
        } else {
            playerAnimations.Walk(false);
        }
    }
}
