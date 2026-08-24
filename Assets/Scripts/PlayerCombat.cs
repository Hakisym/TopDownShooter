using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] PlayerInputReader playerInput;
    [SerializeField] WeaponSystem weaponSystem;

    public bool WeaponEquipped => weaponSystem.HasWeapon;

    void OnEnable() {
        playerInput.Reload += Reload;
        playerInput.SelectWeapon += SwitchWeapon;
    }

    void SwitchWeapon(int index) {
        weaponSystem.SwitchWeapon(index);
    }

    public void Tick(bool attackHeld) {
        weaponSystem.Fire(attackHeld);
    }

    void Reload() {
        weaponSystem.Reload();
    }

    bool CanAttack() {
        // 死亡、换弹、眩晕等状态检查
        return true;
    }
}