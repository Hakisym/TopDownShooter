using System;
using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip fireClip;

    void Start() {
        weapon.OnFire += Weapon_OnFire;
    }

    void Weapon_OnFire(HitInfo obj) {
        audioSource.PlayOneShot(fireClip);
    }
}