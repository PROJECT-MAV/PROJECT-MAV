/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerTransform;

    [Header("Flip Rotation Stats")]
    [SerializeField] private float _flipYRotationTime = 0.5f;

    private Coroutine _turnCorutine;
    private PlayerPrefs _player;
    private bool _isFacingRight;
    
     private void Awake()
    {
        _player = _playerTransform.gameObject.GetComponent<PlayerPrefs>();
        _isFacingRight = _player.IsFacingRight;
    }

    private void Update()
    {
        //카메라 오브젝트가 플레이어 따라다님
        transform.position = _playerTransform.position;
    }

    public void CallTurn()
    {
        _turnCorutine = StartCoroutine(FlipYLerp());
    }

    private IEnumerator FlipYLerp()
    {
        float startRotation = transform.localEulerAngles.y;
        float endRotation = DetermineEndROtation();
        float yRotation = 0f;

        float elapsedTime = 0f;
        while(elapsedTime < _flipYRotationTime)
        {
            elapsedTime += Time.deltaTime;

            yRotation = Mathf.Lerp(startRotation, endRotation, (elapsedTime / _flipYRotationTime));
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

            yield return null;
        }
    }

    private float DetermineEndROtation()
    {
        _isFacingRight = !_isFacingRight;

        if(isFacingRight)
        {
            return 180f;
        }
        else
        {
            return 0f;
        }
    }
}
*/