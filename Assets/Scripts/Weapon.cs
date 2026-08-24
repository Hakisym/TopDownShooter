using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public event Action<HitInfo> OnFire;
    
    [SerializeField] WeaponData data;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] LayerMask hitLayer;
    
    int currentAmmo;
    float nextFireTime;
    bool hasFired;
    
    WeaponState state;

    void Awake() {
        currentAmmo = data.magazineSize;
        state = WeaponState.Ready;
    }

    public void ProcessFireInput(bool attackHeld) {
        if (!attackHeld) {
            // Reset when release button
            hasFired = false;
            return;
        }

        if (data.fireMode == FireMode.SemiAuto && hasFired)
            return;

        // Has weapon successfully fired during attack pressed?
        if (TryFire()) hasFired = true;
    }

    bool TryFire() {
        // Is weapon ready to fire/reach fire interval/has ammo
        if (state != WeaponState.Ready) return false;
        if (Time.time < nextFireTime) return false;
        if (currentAmmo <= 0) return false;

        currentAmmo--;
        nextFireTime = Time.time + data.FireInterval;

        var hitInfo = FireHitscan();

        HandleHit(hitInfo);
        
        OnFire?.Invoke(hitInfo);

        return true;
    }

    void HandleHit(HitInfo hitInfo) {
        if (!hitInfo.hasHit) return;

        var collider = hitInfo.hitCollider;

        var damageable = collider.GetComponentInParent<IDamageable>();

        damageable?.TakeDamage(data.damage);
        
        var hitResponse = collider.GetComponentInParent<IHitResponse>();

        hitResponse?.OnHit(hitInfo);
    }

    HitInfo FireHitscan() {
        var ray = new Ray(muzzlePoint.position, muzzlePoint.forward);
        var hitInfo = new HitInfo
        {
            origin = ray.origin,
            direction = ray.direction,
            hasHit = false
        };
        
        if (Physics.Raycast(ray, out var hit, Helper.MAX_SCREEN_DISTANCE, hitLayer)) {
            hitInfo.hasHit = true;
            hitInfo.hitPoint = hit.point;
            hitInfo.hitNormal = hit.normal;
            hitInfo.hitCollider = hit.collider;
        }

        return hitInfo;
    }

    public void Reload() {
        if (state != WeaponState.Ready) return;
        if (currentAmmo >= data.magazineSize) return;

        StartCoroutine(ReloadRoutine());
    }

    IEnumerator ReloadRoutine() {
        state = WeaponState.Reloading;

        yield return new WaitForSeconds(data.reloadDuration);
        
        currentAmmo = data.magazineSize;

        state = WeaponState.Ready;
    }
}

public enum WeaponState
{
    Ready,
    Reloading
}

public struct HitInfo
{
    public Vector3 origin;
    public Vector3 direction;

    public bool hasHit;
    public Vector3 hitPoint;
    public Vector3 hitNormal;
    
    public Collider hitCollider;
}