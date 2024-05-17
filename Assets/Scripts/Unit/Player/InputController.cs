using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : BehaviorController
{
    public void OnMove(InputAction.CallbackContext input)
    {
        Vector2 direction = input.ReadValue<Vector2>().normalized;
        CallMoveEvent(direction);
    }
}
