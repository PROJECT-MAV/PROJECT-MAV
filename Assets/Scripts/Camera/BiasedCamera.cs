using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BiasedCamera : MonoBehaviour
{
    private CinemachineVirtualCamera vCam;
    private CinemachineFramingTransposer _framingTransposer;

    void Awake()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        _framingTransposer = vCam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    void Update()
    {
        if (_framingTransposer != null)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _framingTransposer.m_TrackedObjectOffset = new Vector3(1, _framingTransposer.m_TrackedObjectOffset.y, _framingTransposer.m_TrackedObjectOffset.z);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                _framingTransposer.m_TrackedObjectOffset = new Vector3(-1, _framingTransposer.m_TrackedObjectOffset.y, _framingTransposer.m_TrackedObjectOffset.z);
            }
        }
    }
}
