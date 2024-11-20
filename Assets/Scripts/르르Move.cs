using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(르르Stat))]
public class 르르Move : MonoBehaviour
{
    [Header("Camera Stuff")]
    [SerializeField] private GameObject _cameraFollowGO;

    [Header("Move Speed")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 20f;
    [SerializeField] float rotationSpeed = 0.5f; // 회전 속도


    private Rigidbody2D ruruBody;
    private PlayerInput playerInput;
    private 르르InputAction playerInputActions;
    private SpriteRenderer spriteRenderer;
    protected 르르Stat ruruStat;
    private Animator ruruAnim;

    public int maxJumpCount = 2;
    int jumpCount = 2;
    int k = 1;
    public bool isFacingRight;
    bool isJumping;
    bool isWalking;
    private CameraFollowObject _cameraFollowObject;
    private Vector3 up = new Vector3(0, 1, 0);
    private bool isRotating = false; // 회전 중인지 여부
    private float targetAngle; // 목표 회전 각도

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

        _cameraFollowObject = _cameraFollowGO.GetComponent<CameraFollowObject>();
        

    }

    void Update()
    {
        if (isRotating)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, rotationSpeed);
            if (Mathf.Approximately(angle, targetAngle))
            {
                isRotating = false;
            }
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            targetAngle = transform.eulerAngles.z + 180f;
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 0.1f);
            isRotating = true;
            up.y *= -1;
            k *= -1;
            ruruBody.gravityScale *= -1;
        }

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
        direction = new Vector2(input.x * k, input.y);

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
            ruruBody.velocity = up * jumpSpeed;
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
