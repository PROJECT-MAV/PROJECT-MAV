using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class 르르Move : MonoBehaviour
{
    Rigidbody2D ruruBody;
    PlayerInput playerInput;
    Player playerInputActions;

    float inputHorizontal;
    float moveSpeed = 10f;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new Player();
        playerInputActions.Player.Jump.performed += Jump();
        ruruBody = gameObject.GetComponent<Rigidbody2D>();
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
        
        Debug.Log("르르Moving!");
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump!");
    }

    public void Flip()
    {

    }
}
