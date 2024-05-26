using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class P_Control : MonoBehaviour
{
    public LayerMask groundLayer;
    public Rigidbody playerRigid;
    public Animator anime;
    /////////////////////////// Character Info Variable ///////////////////////////
    public float maxHealth = 100f;
    private float curHealth;
    /////////////////////////////// Motion Variable ///////////////////////////////
    public float moveSpeed = 5f;
    public float dashSpeed = 1.25f;
    public float rotSpeed = 15f;
    public float jumpPower = 5f;

    private bool isGrounded;
    /////////////////////////////// Fight Variable ////////////////////////////////
    P_Attack howAttack;
    float attackDelay;
    
    private bool isAttack;
    private bool Barriering;
    ///////////////////////////////////////////////////////////////////////////////

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {
        curHealth = maxHealth;
        playerRigid = GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();
        howAttack = GetComponent<P_Attack>();
        
    }

    void Update()
    {
        Move();
        Jump();
        Attack();
        Barrier();
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /////////////////////////////////////////////////// Judgment Function ///////////////////////////////////////////////////

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Stage") // 땅 판정
        {
            isGrounded = true;
            anime.SetBool("IsJump", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Attack"))
        {
            anime.SetTrigger("OnHit");
            Debug.Log("피해를 입었습니다.");
            {
                
            }
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //////////////////////////////////////////////////// Motion Function ////////////////////////////////////////////////////
    private void Move()
    {
        var h = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(h, 0, 0) * moveSpeed;
        Vector3 moveDistance = dir * Time.deltaTime;

        if(dir!=Vector3.zero && !Barriering) // 캐릭터 움직임 방향
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, Mathf.Atan2(0,h) * Mathf.Rad2Deg + 90, 0), rotSpeed * Time.deltaTime);
        }

        if(!isAttack && !Barriering)
        {
            playerRigid.MovePosition(playerRigid.position + moveDistance);
            anime.SetBool("IsWalk", dir!=Vector3.zero);
        }

        if(!isAttack && !Barriering && Input.GetKey(KeyCode.LeftShift))
        {
            moveDistance *= dashSpeed;
            playerRigid.MovePosition(playerRigid.position + moveDistance);
            anime.SetBool("IsWalk", dir!=Vector3.zero);
        }
    }

    private void Jump()
    {

        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            playerRigid.AddForce(Vector3.up * Mathf.Sqrt(jumpPower * -Physics.gravity.y), ForceMode.Impulse);
            anime.SetTrigger("doJump");
            anime.SetBool("IsJump", true);
            isGrounded = false;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    //////////////////////////////////////////////////// Fight Function /////////////////////////////////////////////////////
    private void Attack()
    {
        attackDelay += Time.deltaTime;
        isAttack = howAttack.attackSpeed > attackDelay;

        if(Input.GetKeyDown(KeyCode.Z) && !isAttack && !Barriering)
        {
            howAttack.Use();
            anime.SetTrigger("doAttack");
            attackDelay = 0;
        }
    }

    private void Barrier()
    {
        if(Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            anime.SetTrigger("doBarrier");
            anime.SetBool("IsBarrier", true);
            Barriering = true;
        }

        if(Input.GetKeyUp(KeyCode.B) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            anime.SetBool("IsBarrier", false);
            Barriering = false;
        }
    }
}
