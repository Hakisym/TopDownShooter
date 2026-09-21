using System;
using UnityEngine;

[Serializable]
public class PlayerRuntimeContext
{
    public PlayerInputContext InputContext;
    public PlayerWeaponContext WeaponContext;
    
    public void ClearFrame() {
        InputContext = default;
    }
}

[Serializable]
public struct PlayerInputContext
{
    public Vector2 MoveInput;
    public Vector2 MousePosition;
    public bool attackHeld;
}

[Serializable]
public struct PlayerWeaponContext
{
    public bool weaponEquipped;
}
