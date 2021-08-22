using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpController : MonoBehaviour
{
    private RebindJumping gameActions;

    private Rigidbody rb;

    private void OnEnable()
    {
        gameActions = InputManager.inputActions;

        gameActions.GameControls.Jump.started += DoJump;
        gameActions.GameControls.Enable();

        rb = this.GetComponent<Rigidbody>();
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }
}
