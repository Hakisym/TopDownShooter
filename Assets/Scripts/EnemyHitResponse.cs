using UnityEngine;

public class EnemyHitResponse : MonoBehaviour, IHitResponse
{
    [SerializeField] ParticleSystem bloodEffect;
    
    public void OnHit(HitInfo hitInfo) {
        Instantiate(bloodEffect, hitInfo.hitPoint, Quaternion.LookRotation(hitInfo.hitNormal));
    }
}