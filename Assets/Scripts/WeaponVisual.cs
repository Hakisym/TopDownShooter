using System;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponVisual : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] GameObject bulletVisual;

    void Start() {
        weapon.OnFire += Weapon_OnFire;
    }

    void Weapon_OnFire(HitInfo hitInfo) {
        var instantiate = Instantiate(bulletVisual, hitInfo.origin, Quaternion.LookRotation(hitInfo.direction));
        
        instantiate.GetComponent<BulletVisual>().Setup(hitInfo);
    }
}