using System;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] Transform weaponSocket;
    [SerializeField] float aimRotationSpeed = 1440f;
    [SerializeField] float aimDeadZone = 1f;
    [SerializeField] float minAimDistance = 5f;
    
    public Vector3 AimDirection { get; private set; }

    void Awake() {
        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    public void Tick(Vector2 mousePos, bool weaponEquipped) {
        AimDirection = GetAimDirection(mousePos, weaponEquipped);
        
        Aim(AimDirection);
    }

    void Aim(Vector3 targetDirection) {
        if (targetDirection == Vector3.zero) return;
        
        var targetRotation = Quaternion.LookRotation(targetDirection);
        
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, targetRotation, 
            Time.deltaTime * aimRotationSpeed
            );
    }
    
    Vector3 GetAimDirection(Vector2 mousePos, bool weaponEquipped) {
        var ray = playerCamera.ScreenPointToRay(mousePos);

        var plane = new Plane(Vector3.up, weaponSocket.position);

        if (!plane.Raycast(ray, out var rayDistance))
            return Vector3.zero;

        var aimPoint = ray.GetPoint(rayDistance);

        var toAim = aimPoint - transform.position;
        toAim.y = 0f;

        float distance = toAim.magnitude;

        if (distance < 0.001f)
            return Vector3.zero;

        // 空手：直接朝鼠标
        if (!weaponEquipped)
            return toAim.normalized;

        // weaponSocket 相对于 Player 中心的左右偏移
        var localSocketPos = transform.InverseTransformPoint(
            weaponSocket.position
        );

        float lateralOffset = localSocketPos.x;

        // 已经近到没有几何解了
        if (distance <= Mathf.Abs(lateralOffset))
            return Vector3.zero;

        // 获取player需要偏移的角度，使weapon与aimpoint相交
        float offsetAngle = Mathf.Asin(
            lateralOffset / distance
        ) * Mathf.Rad2Deg;

        var targetDirection =
            Quaternion.AngleAxis(-offsetAngle, Vector3.up)
            * toAim.normalized;

        return targetDirection;
    }
}