using System;
using UnityEngine;

public class WallHitResponse : MonoBehaviour, IHitResponse
{
    [SerializeField] ParticleSystem sparkEffect;
    
    public void OnHit(HitInfo hitInfo) {
        Instantiate(sparkEffect, hitInfo.hitPoint, Quaternion.LookRotation(hitInfo.hitNormal));
    }
}