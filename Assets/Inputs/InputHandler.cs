using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Input Systemden gelen inputlarý okuduðum ve
// bu inputlarý alakalý eventlere subscribe olmak için kullandýðým script.

public class InputHandler : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 movementValue { get; private set; }
    public float movementForwardValue { get; private set; }
    public float movementRightValue { get; private set; }
    
    

    public event Action dodgeEvent;
    public event Action reloadEvent;


    private Controls controls;

    void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }
    private void OnDestroy()
    {
        controls.Player.Disable();
    }
    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        dodgeEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementValue = context.ReadValue<Vector2>();
        movementForwardValue = movementValue.y;
        movementRightValue = movementValue.x;
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        reloadEvent?.Invoke();
    }
}
