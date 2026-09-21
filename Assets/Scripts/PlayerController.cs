using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerInputReader playerInput;
    [SerializeField] PlayerAim playerAim;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerCombat playerCombat;
    [SerializeField] PlayerHealth playerHealth;

    PlayerRuntimeContext ctx;

    void Awake() {
        ctx = new PlayerRuntimeContext();
    }

    void Update() {
        UpdateInputContext();

        playerAim.Tick(ctx);
        
        playerMovement.Tick(ctx);

        playerCombat.Tick(ctx);
        
        ctx.ClearFrame();
    }

    void UpdateInputContext() {
        ctx.InputContext.MoveInput = playerInput.MoveInput;
        ctx.InputContext.MousePosition = playerInput.MousePosition;
        ctx.InputContext.attackHeld = playerInput.AttackHeld;
    }
}
