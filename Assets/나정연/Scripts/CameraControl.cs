using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public FocusLevel FocusLevel;

    public List<GameObject> Players;

    public float DepthUpdateSpeed = 5f;  // 줌인 줌아웃 속도
    public float AngleUpdateSpeed = 7f;  // 위아래 움직임 속도
    public float PositionUpdateSpeed = 5f; // 좌우 움직임 속도

    public float DepthMax = -10f;
    public float DepthMin = -22f;

    public float AngleMax = 11f;
    public float AngleMin = 3f;

    private float CameraEulerX;
    private Vector3 CameraPosition;


    // Start is called before the first frame update
    void Start()
    {
        Players.Add(FocusLevel.gameObject);
    }


    // Update is called once per frame
    private void LateUpdate()
    {
        CalculateCameraLocation();
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 position = gameObject.transform.position;
        if(position != CameraPosition)
        {
            Vector3 newPosition = Vector3.zero;
            newPosition.x = Mathf.MoveTowards(position.x, CameraPosition.x, PositionUpdateSpeed*Time.deltaTime);
            newPosition.y = Mathf.MoveTowards(position.y, CameraPosition.y, PositionUpdateSpeed * Time.deltaTime);
            newPosition.z = Mathf.MoveTowards(position.z, CameraPosition.z, DepthUpdateSpeed * Time.deltaTime);
            gameObject.transform.position = newPosition;
        }

        Vector3 localEulerAngles = gameObject.transform.localEulerAngles;
        if(localEulerAngles.x != CameraEulerX) 
        {
            Vector3 targetEulerAngles = new Vector3(CameraEulerX, localEulerAngles.y, localEulerAngles.z);
            gameObject.transform.localEulerAngles = Vector3.MoveTowards(localEulerAngles, targetEulerAngles, AngleUpdateSpeed*Time.deltaTime);
        }
    }

    private void CalculateCameraLocation()
    {
        Vector2 averageCenter = Vector3.zero;   
        Vector3 totalPosition = Vector3.zero; //플레이어들의 position합
        Bounds playerBounds = new Bounds();

        for(int i = 0; i< Players.Count; i++)
        {
            Vector3 playerPosition = Players[i].transform.position;

            if(!(FocusLevel.FocusBounds.Contains(playerPosition)))
            {
                float playerX = Mathf.Clamp(playerPosition.x,FocusLevel.FocusBounds.min.x, FocusLevel.FocusBounds.max.x);
                float playerY = Mathf.Clamp(playerPosition.y, FocusLevel.FocusBounds.min.y, FocusLevel.FocusBounds.max.y); 
                float playerZ = Mathf.Clamp(playerPosition.z, FocusLevel.FocusBounds.min.z, FocusLevel.FocusBounds.max.z);
                playerPosition = new Vector3(playerX, playerY, playerZ);
            }
            totalPosition += playerPosition;
            playerBounds.Encapsulate(playerPosition);
        }
        averageCenter = (totalPosition / Players.Count);

        float extents = (playerBounds.extents.x + averageCenter.x);
        float lerpPercent = Mathf.InverseLerp(0, (FocusLevel.HalfXBounds + FocusLevel.HalfYBounds) / 2, extents);

        float depth = Mathf.Lerp(DepthMax, DepthMin, lerpPercent); 
        float angle = Mathf.Lerp(AngleMax, AngleMin, lerpPercent);

        CameraEulerX = angle;
        CameraPosition = new Vector3(averageCenter.x, averageCenter.y, depth);
    }
}