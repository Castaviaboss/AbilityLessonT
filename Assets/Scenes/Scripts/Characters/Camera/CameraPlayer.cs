using System;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private GameObject cameraBox;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector2 cameraOffset;
    

    private void LateUpdate()
    {
        SmoothFollow();
    }

    private void SmoothFollow()
    {
        Vector2 targetPosition = new Vector2(target.position.x + cameraOffset.x, target.position.y + cameraOffset.y);
        Vector2 smoothFollow = Vector2.Lerp(transform.position, targetPosition, smoothSpeed);

        transform.position = smoothFollow;
    }
}
