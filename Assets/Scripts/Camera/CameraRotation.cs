using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.5f; // ȸ�� �ӵ�
    private bool isRotating = false; // ȸ�� ������ ����
    private float targetAngle; // ��ǥ ȸ�� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        }
    }
}
