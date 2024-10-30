using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 3f;
    [SerializeField] float jumpSpeed = 5f;

    Vector2 moveInput;
    Rigidbody myRigidbody;
    Animator myAnimator;
    Collider myBodyCollider;
    bool isGrounded = true; // 캐릭터가 땅에 있는지 여부를 추적합니다.
    bool isJumping = false; // 캐릭터가 점프 중인지 여부를 추적합니다.
    bool isAlive = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!isGrounded) { return; } // 캐릭터가 땅에 없을 때 점프하지 않도록 수정합니다.

        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector3(0f, jumpSpeed, 0f);
            isJumping = true; // 점프 중임을 표시합니다.
            myAnimator.SetBool("isJumping", true); // 애니메이터에 점프 중임을 알려줍니다.
        }
    }

    void Run()
    {
        var h = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(h, 0, 0) * runSpeed;
        Vector3 moveDistance = dir * Time.deltaTime;

        myRigidbody.MovePosition(myRigidbody.position + moveDistance);
        myAnimator.SetBool("isRunning", dir!=Vector3.zero);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = moveInput.magnitude > 0.1f;
        
        if (playerHasHorizontalSpeed)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(moveInput.x, 0f, moveInput.y));
        }
    }

    // OnCollisionEnter를 사용하여 캐릭터가 땅에 닿았을 때 땅에 있는지 여부를 감지합니다.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
            myAnimator.SetBool("isJumping", false);
        }
    }

    // OnCollisionExit를 사용하여 캐릭터가 땅에서 벗어났을 때 땅에 있는지 여부를 감지합니다.
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
