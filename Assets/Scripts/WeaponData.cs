using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public FireMode fireMode;
    public int magazineSize;
    public float fireRate; // RPM
    public float damage;
    public float reloadDuration;

    public float FireInterval => 60 / fireRate;
}

public enum FireMode
{
    SemiAuto,
    FullAuto
}