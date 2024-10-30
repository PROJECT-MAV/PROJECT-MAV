using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    [SerializeField] // editor에서 볼 수 있게 해줌
    private Vector3 offset;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // LateUpdate is called right after Update called
    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer() {
        transform.position = target.TransformPoint(offset);
    }
}
