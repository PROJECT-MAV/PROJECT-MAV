using Unity.VisualScripting;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float maxChaseProbability = 0.6f;
    [SerializeField] float minChaseProbability = 0.4f;
    [SerializeField] float maxWeightDistance = 10f;
    [SerializeField] float decisionInterval = 0.2f;

    Rigidbody myRigidbody;
    Animator myAnimator;
    bool isAlive = true;
    float decisionTimer = 0f;
    float random = 0f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isAlive) { return; }
        decisionTimer -= Time.deltaTime;
        if (decisionTimer < 0f)
        {
            random = Random.value;
            decisionTimer = decisionInterval;
        }
        else
        {
            Run(random);
        }
    }

    void Run(float random)
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            Transform playerTransform = playerObject.transform;
            float playerX = playerTransform.position.x;
            float distance = Mathf.Abs(playerX - transform.position.x);
            float weight = Mathf.Clamp01(distance / maxWeightDistance);
            float chaseProbability = Mathf.Lerp(minChaseProbability, maxChaseProbability, weight);
            Vector3 dir;
            if (random < chaseProbability)
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(Mathf.Sign(playerX - transform.position.x), 0f, 0f));
                dir = new Vector3(Mathf.Sign(playerX - transform.position.x), 0, 0) * runSpeed;
            }
            else if (random < 0.6f)
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(-Mathf.Sign(playerX - transform.position.x), 0f, 0f));
                dir = new Vector3(-Mathf.Sign(playerX - transform.position.x), 0, 0) * runSpeed;
            }
            else
            {
                dir = Vector3.zero;
            }
            Vector3 moveDistance = dir * Time.deltaTime;
            myRigidbody.MovePosition(myRigidbody.position + moveDistance);
            myAnimator.SetBool("isRunning", dir != Vector3.zero);
        }
    }
}
