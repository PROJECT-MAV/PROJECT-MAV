using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Camera : MonoBehaviour
{
    public GameObject Player;
    public float follow_speed = 4.0f;
    public float x = 10;
    public float y = 1;
    public float z;

    Transform Camera_transform;
    Transform Player_transform;

    void Awake()
    {
        Camera_transform = GetComponent<Transform>();
        Player_transform = Player.GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 FixedPos = new Vector3(Player.transform.position.x + x, Player.transform.position.y + y, Player.transform.position.z + z);
        Camera_transform.position = Vector3.Lerp(Camera_transform.position, FixedPos, follow_speed * Time.deltaTime);
    }
}
