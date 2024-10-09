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
    private Animator ruruAnim;

    float moveSpeed = 5f;
    public int maxJumpCount = 2;
    int jumpCount = 2;
    bool isFacingRight;
    bool isJumping;
    bool isWalking;

    public Vector2 direction { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        ruruStat = GetComponent<르르Stat>();
        ruruBody = gameObject.GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new 르르InputAction();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ruruAnim = gameObject.GetComponent<Animator>();

        playerInputActions.Player.Enable();
        

    }

    void Update()
    {
        isJumping = playerInputActions.Player.Jump.WasPressedThisFrame();
        if (isJumping)
        {
            Jump();
            Debug.Log("Jumping!");
        }
    }

    void FixedUpdate()
    {
        Move();
        
    }    


    public void Move()
    {
        Vector2 input = playerInputActions.Player.Move.ReadValue<Vector2>();
        direction = new Vector2(input.x, input.y);

        ruruBody.velocity = direction * moveSpeed + Vector2.up * ruruBody.velocity.y;
        isWalking = (input.x != 0);
        ruruAnim.SetBool("isWalking", isWalking);
        isFacingRight = (input.x == 1);
        if (isFacingRight)
        {
            FlipRight();
        }
        else
        {
            FlipLeft();
        }
    }

    public void Jump()
    {
      
        if (jumpCount > 0 && isJumping)
        {
            jumpCount--;
            ruruBody.AddForce(Vector3.up * 10f, ForceMode2D.Impulse);
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpCount = maxJumpCount;
        }
    }

    public void FlipRight()
    {
        spriteRenderer.flipX = true;

    }
    public void FlipLeft()
    {
        spriteRenderer.flipX = false;
    }
}
