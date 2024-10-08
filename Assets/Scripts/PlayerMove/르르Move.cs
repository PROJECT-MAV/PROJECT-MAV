using UnityEngine;
using UnityEngine.InputSystem;

public class 르르Move : MonoBehaviour
{
    private Rigidbody2D ruruBody;
    private PlayerInput playerInput;
    private 르르InputAction playerInputActions;


    float moveSpeed = 2f;
    bool isFacingRight;

    // Start is called before the first frame update
    private void Awake()
    {
        ruruBody = gameObject.GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new 르르InputAction();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Move.performed += Move;
        playerInputActions.Player.Move.performed += Flip;
    }



    private void FixedUpdate()
    { 
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        ruruBody.AddForce(new Vector2(inputVector.x, 0) * moveSpeed, ForceMode2D.Impulse);
    }
        void OnEnable()
        {


        }

        void OnDisable()
        {

        }

        public void Move(InputAction.CallbackContext context)
        {
            

        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("르르Jumping!");
                ruruBody.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);
            }
        }

        public void Flip(InputAction.CallbackContext context)
        {
        /*
            if (inputVector.x == 1)
            {
                isFacingRight = true;
            }
            else if (inputVector.x == -1)
            {
                isFacingRight = false;
            }
        */
        }
        
    }
