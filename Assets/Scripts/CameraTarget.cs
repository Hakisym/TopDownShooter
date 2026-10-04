using System;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] Transform target;

    [Header("Map Bounds")] 
    [SerializeField] Vector2 mapCenter = Vector2.zero;
    [SerializeField] Vector2 mapSize = new Vector2(50f, 50f);

    [Header("Camera")] 
    [SerializeField] Camera targetCamera;

    void LateUpdate() {
        var position = target.position;

        float halfHeight = targetCamera.orthographicSize;
        float halfWidth = halfHeight * targetCamera.aspect;
        
        // Camera X rotation = 60°
        float angle = targetCamera.transform.eulerAngles.x * Mathf.Deg2Rad;
        
        // Vertical screen size projected onto the XZ ground plane
        float groundHalfHeight = halfHeight / Mathf.Sin(angle);

        float mapHalfWidth = mapSize.x * 0.5f;
        float mapHalfDepth = mapSize.y * 0.5f;

        position.x = Mathf.Clamp(
            position.x,
            mapCenter.x - mapHalfWidth + halfWidth,
            mapCenter.x + mapHalfWidth - halfWidth
        );

        position.z = Mathf.Clamp(
            position.z,
            mapCenter.y - mapHalfDepth + groundHalfHeight,
            mapCenter.y + mapHalfDepth - groundHalfHeight
        );

        transform.position = position;
    }
}