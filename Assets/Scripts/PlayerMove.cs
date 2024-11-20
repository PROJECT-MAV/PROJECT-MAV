using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    int k = 1;
    int currentJumpCount = 2;
    bool isJumping;
    bool isWalking;
    public bool isFacingRight;
    bool isRotating = false;
    public Vector2 direction { get; private set; }
    [Header("Camera Stuff")]
    [SerializeField] private GameObject _cameraFollowGO;
    private Rigidbody2D _playerBody;
    private PlayerInput _playerInput;
    private PlayerInputAction _playerInputActions;
    private SpriteRenderer _spriteRenderer;
    private Animator _playerAnim;
    private 르르Stat _playerStat;
    private CameraFollowObject _cameraFollowObject;
    private float _fallSpeedYDampingChangeThreshold;
    private Vector3 up = new Vector3(0, 1, 0);
    private float targetAngle; // 목표 회전 각도


    // Start is called before the first frame update
    private void Awake()
    {
        // ruruStat = GetComponent<르르Stat>();
        _playerBody = gameObject.GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _playerInputActions = new PlayerInputAction();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _playerAnim = gameObject.GetComponent<Animator>();
        _playerStat = GetComponent<르르Stat>();

        _playerInputActions.Player.Enable();

        _cameraFollowObject = _cameraFollowGO.GetComponent<CameraFollowObject>();
        _fallSpeedYDampingChangeThreshold = CameraManager.instance.fallSpeedYDampingChangeThreshold;
    }

    private void Update()
    {
        if (isRotating)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, _playerStat.GetRotationSpeed);
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
            _playerBody.gravityScale *= -1;
        }

        isJumping = _playerInputActions.Player.Jump.WasPressedThisFrame();
        if (isJumping)
        {
            Jump();
        }

        if(_playerBody.velocity.y < _fallSpeedYDampingChangeThreshold && !CameraManager.instance.IsLerpingYDamping && !CameraManager.instance.LerpedFromPlayerFalling)
        {
            CameraManager.instance.LerpYDamping(true);
        }

        if(_playerBody.velocity.y >= 0 && !CameraManager.instance.IsLerpingYDamping && !CameraManager.instance.LerpedFromPlayerFalling)
        {
            CameraManager.instance.LerpedFromPlayerFalling = false;
            CameraManager.instance.LerpYDamping(false);
        }
    }

    void FixedUpdate()
    {
        Move();
    }     


    public void Move()
    {
        Vector2 input = _playerInputActions.Player.Move.ReadValue<Vector2>();
        direction = new Vector2(input.x * k, input.y);

        _playerBody.velocity = direction * _playerStat.GetMoveSpeed + Vector2.up * _playerBody.velocity.y;
        isWalking = (input.x != 0);
        _playerAnim.SetBool("isWalking", isWalking);
        isFacingRight = (input.x == 1);
        if (isFacingRight)
        {
            FlipRight();
            //Turn CameraFollowObject
            _cameraFollowObject.CallTurn();

        }
        else
        {
            FlipLeft();
            _cameraFollowObject.CallTurn();
        }
    }

    public void Jump()
    {
      
        if (currentJumpCount > 0 && isJumping)
        {
            currentJumpCount--;
            _playerBody.velocity = up * _playerStat.GetJumpSpeed;
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            currentJumpCount = _playerStat.GetMaxJumpCount;
        }
    }

    public void FlipRight()
    {
        _spriteRenderer.flipX = true;

    }
    public void FlipLeft()
    {
        _spriteRenderer.flipX = false;
    }
}
