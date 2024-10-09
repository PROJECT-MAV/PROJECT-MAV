using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(르르Stat))]
public class 르르Move : MonoBehaviour
{
    private Rigidbody2D ruruBody;
    private PlayerInput playerInput;
    private 르르InputAction playerInputActions;
    private SpriteRenderer spriteRenderer;
    protected 르르Stat ruruStat;

    float moveSpeed = 5f;
    bool isFacingRight;
    bool isJumping;
    public Vector2 direction { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        ruruStat = GetComponent<르르Stat>();
        ruruBody = gameObject.GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new 르르InputAction();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Move.performed += Move;
    }



    void FixedUpdate()
    {
        Vector2 input = playerInputActions.Player.Move.ReadValue<Vector2>();
        direction = new Vector2(input.x, input.y);
        ruruBody.velocity = direction * moveSpeed + Vector2.up * ruruBody.velocity.y;
    }    


    public void Move(InputAction.CallbackContext context)
    {
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isJumping = true;
            Debug.Log("르르Jumping!");
            ruruBody.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);
        }
    }

    public void Flip()
    {
        if(direction != Vector2.zero)
        {
            Quaternion targetAngle = Quaternion.LookRotation(direction);
            //ruruBody.rotation = targetAngle;
        }

        /* if (isFacingRight)
        {
            spriteRenderer.flipX = false;
        }
        else if (!isFacingRight)
        {
            spriteRenderer.flipX = true;
        }
        */

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
