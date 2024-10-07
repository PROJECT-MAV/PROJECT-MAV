using UnityEngine;
using UnityEngine.InputSystem;

public class 르르Move : MonoBehaviour
{
    private Rigidbody2D ruruBody;
    private PlayerInput playerInput;
    private 르르InputAction playerInputActions;

    public Vector2 inputVector;
    float moveSpeed = 10f;
    bool isFacingRight;

    // Start is called before the first frame update
    private void Awake()
    {
        ruruBody = gameObject.GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        르르InputAction playerInputActions = new 르르InputAction();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Move.performed += Move;
        playerInputActions.Player.Move.performed += Flip;
    }

    private void FixedUpdate()
    {
        
    }

    private void Update()
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
        inputVector = context.ReadValue<Vector2>();

        if (inputVector.x == 1 && isFacingRight)
        {
            ruruBody.velocity = new Vector2(inputVector.x * moveSpeed, ruruBody.velocity.y);
            Debug.Log("르르Moving!");
            Debug.Log(context);
        }
        else if(inputVector.x == -1 && !isFacingRight)
        {
            ruruBody.velocity = new Vector2(inputVector.x * -moveSpeed, ruruBody.velocity.y);
        }

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("르르Jumping!");
            ruruBody.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);
        }
    }

    public void Flip(InputAction.CallbackContext context)
    {
        if(inputVector.x == 1)
        {
            isFacingRight = true;
        }
        else if(inputVector.x == -1)
        {
            isFacingRight= false;
        }
    }
}
