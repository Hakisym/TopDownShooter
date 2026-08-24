using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public event UnityAction Reload = delegate { };
    public event UnityAction<int> SelectWeapon = delegate { };
    public Vector2 MousePosition => inputActions.Player.MousePosition.ReadValue<Vector2>();
    public Vector2 MoveInput => inputActions.Player.Move.ReadValue<Vector2>();
    public bool AttackHeld => inputActions.Player.Attack.IsPressed();

    PlayerInputActions inputActions;

    void Awake() {
        inputActions = new PlayerInputActions();
    }

    void OnEnable() {
        inputActions.Player.Enable();

        inputActions.Player.Reload.started += OnReload;
        inputActions.Player.SelectWeapon.started += OnSelectWeapon;
    }

    void OnDisable() {
        inputActions.Player.Reload.started -= OnReload;
        inputActions.Player.SelectWeapon.started -= OnSelectWeapon;
        
        inputActions.Player.Disable();
    }

    void OnDestroy() {
        inputActions.Dispose();
    }

    void OnReload(InputAction.CallbackContext context) {
        Reload.Invoke();
    }

    void OnSelectWeapon(InputAction.CallbackContext context) {
        var slot = context.control.name switch
        {
            "1" => 0,
            "2" => 1,
            "3" => 2,
            "4" => 3,
            "5" => 4,
            "6" => 5,
            "7" => 6,
            "8" => 7,
            "9" => 8,
            "0" => 9,
            _=>-1
        };

        if (slot >= 0) 
            SelectWeapon.Invoke(slot);
    }
}
