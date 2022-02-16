using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    public float SmoothSpeed = 10f;

    public Vector3 OffSet;

    private void LateUpdate()
    {
        Vector3 desiredPosition = Player.position + OffSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
