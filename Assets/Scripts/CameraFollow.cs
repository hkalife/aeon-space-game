using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform PlayerTransform;

    /*private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    void Start() {
        cameraOffset = transform.position - PlayerTransform.position;
    }

    void LateUpdate() {
        Vector3 newPos = PlayerTransform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        transform.LookAt(PlayerTransform);
    }*/

    void Update() {
        transform.position = new Vector3(PlayerTransform.position.x + 19, PlayerTransform.position.y + 10, PlayerTransform.position.z - 18);
        transform.Rotate(PlayerTransform.rotation.x, PlayerTransform.rotation.y, PlayerTransform.rotation.z);
    }

}
