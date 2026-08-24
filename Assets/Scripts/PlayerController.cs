using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerInputReader playerInput;
    [SerializeField] PlayerAim playerAim;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerCombat playerCombat;

    void Update() {
        var moveInput = playerInput.MoveInput;
        var mousePos = playerInput.MousePosition;
        var attackHeld = playerInput.AttackHeld;
        var hasWeapon = playerCombat.WeaponEquipped;

        playerAim.Tick(mousePos, hasWeapon);
        
        playerMovement.Tick(moveInput);

        playerCombat.Tick(attackHeld);
    }
}
