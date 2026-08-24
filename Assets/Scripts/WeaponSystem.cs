using System;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] Weapon[] weapons;
    int currentWeaponIndex;
    Weapon CurrentWeapon => weapons[currentWeaponIndex];

    public bool HasWeapon => CurrentWeapon != null;

    void Start() {
        EquipWeapon(0);
    }

    public void Fire(bool attackHeld) {
        CurrentWeapon?.ProcessFireInput(attackHeld);
    }

    public void Reload() {
        CurrentWeapon?.Reload();
    }

    public void SwitchWeapon(int index) {
        if (index < 0 || index >= weapons.Length)
            return;

        if (index == currentWeaponIndex)
            return;

        CurrentWeapon.gameObject.SetActive(false);

        currentWeaponIndex = index;

        CurrentWeapon.gameObject.SetActive(true);
    }

    void EquipWeapon(int index) {
        currentWeaponIndex = index;

        for (var i = 0; i < weapons.Length; i++) {
            weapons[i].gameObject.SetActive(i == currentWeaponIndex);
        }
    }
}