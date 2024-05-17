using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : BehaviorController
{
    public void OnMove(InputAction.CallbackContext input)
    {
        Vector2 direction = input.ReadValue<Vector2>().normalized;
        CallMoveEvent(direction);
    }

    public void OnLook(InputAction.CallbackContext input)
    {
        Vector2 direction = input.ReadValue<Vector2>().normalized;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(direction);
        direction = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(direction);
    }
}