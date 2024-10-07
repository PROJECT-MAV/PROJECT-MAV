using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class 르르Move : MonoBehaviour
{
    private Rigidbody2D ruruBody;
    private PlayerInput playerInput;
    private 르르InputAction playerInputActions;

    float inputHorizontal;
    float moveSpeed = 10f;

    // Start is called before the first frame update
    private void Awake()
    {
        ruruBody = gameObject.GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        르르InputAction playerInputActions = new 르르InputAction();
        playerInputActions.Player.Jump.performed += Jump;
  
    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        

    }

    void OnDisable()
    {
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("르르Moving!");
        }

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("르르Jumping!");
        }
    }

    public void Flip()
    {

    }
}
