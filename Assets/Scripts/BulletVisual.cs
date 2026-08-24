using System;
using UnityEngine;

public class BulletVisual : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float lifetime;
    
    public void Setup(HitInfo hitInfo) {
        var targetPoint = hitInfo.hasHit
            ? hitInfo.hitPoint
            : hitInfo.origin + hitInfo.direction * Helper.MAX_SCREEN_DISTANCE;
        
        lineRenderer.SetPosition(0, hitInfo.origin);
        lineRenderer.SetPosition(1, targetPoint);
        
        Destroy(gameObject, lifetime);
    }
}