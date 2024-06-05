using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl : MonoBehaviour
{
    InputControl playerInput; // InputSystem Script불러오는
    CharacterController characterController;
    Animator animator;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    int isWalkHash; // 최적화,
    int isRunHash;
    bool isMovementPressed;
    bool isRunPressed;
    float rotationPerFrame = 5f;

    private void Awake()
    {
        playerInput = new InputControl();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isWalkHash = Animator.StringToHash("isWalking");
        isRunHash = Animator.StringToHash("isRunning");

        playerInput.Story.Walk.started += onWalkInput;
        playerInput.Story.Walk.canceled += onWalkInput;
        // 게임패드 값 받아올때 필요함
        playerInput.Story.Walk.performed += onWalkInput;

        playerInput.Story.Run.started += onRun;
        playerInput.Story.Run.canceled += onRun;
    }
    
    void onRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
        currentRunMovement.x = currentMovementInput.x * 3f;
        currentRunMovement.z = currentMovementInput.y * 3f;
    }

    void handleRotation()
    {
        Vector3 positionToLook;

        positionToLook.x = currentMovement.x;
        positionToLook.y = 0;
        positionToLook.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;

        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLook);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationPerFrame*Time.deltaTime);
        }
        
    }

    void handleAnimationState()
    {
        bool isWalking = animator.GetBool(isWalkHash);
        bool isRunning = animator.GetBool(isRunHash);

        if(isMovementPressed && !isWalking)
        {
            animator.SetBool("isWalking", true);
        }

        else if(!isMovementPressed && isWalking)
        {
            animator.SetBool("isWalking", false);
        }

        if((isMovementPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool(isRunHash, true);
        }
        else if((!isMovementPressed || !isRunPressed) && isRunning)
        {
            animator.SetBool(isRunHash, false);
        }
    }

    void onWalkInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
    }

    void OnEnable()
    {
        playerInput.Story.Enable();
    }

    private void OnDisable()
    {
        playerInput.Story.Disable();
    }
    void Update()
    {
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;

        if (isRunPressed)
        {
            characterController.Move(currentRunMovement * Time.deltaTime);
        }
        else
        {
            characterController.Move(currentMovement * Time.deltaTime);
        }
       
        handleAnimationState();
        handleRotation();
   
    }
}
