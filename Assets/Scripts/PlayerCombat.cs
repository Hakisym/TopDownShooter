using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] PlayerInputReader playerInput;
    [SerializeField] WeaponSystem weaponSystem;

    void OnEnable() {
        playerInput.Reload += Reload;
        playerInput.SelectWeapon += SwitchWeapon;
    }

    void OnDisable() {
        playerInput.Reload += Reload;
        playerInput.SelectWeapon += SwitchWeapon;
    }

    void SwitchWeapon(int index) {
        weaponSystem.SwitchWeapon(index);
    }

    public void Tick(PlayerRuntimeContext ctx) {
        ctx.WeaponContext.weaponEquipped = weaponSystem.HasWeapon;
        
        weaponSystem.Fire(ctx.InputContext.attackHeld);
    }

    void Reload() {
        weaponSystem.Reload();
    }

    bool CanAttack() {
        // 死亡、换弹、眩晕等状态检查
        return true;
    }
}