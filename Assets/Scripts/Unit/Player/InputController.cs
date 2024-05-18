using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : BehaviorController
{
    private Camera camera;

    protected override void Awake()
    {
        base.Awake();
        camera = Camera.main;
    }
    public void OnMove(InputValue input)
    {
        Vector2 direction = input.Get<Vector2>().normalized;
        CallMoveEvent(direction);
    }

    public void OnLook(InputValue input)
    {
        Vector2 direction = input.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(direction);
        direction = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(direction);
    }

    public void OnFire(InputValue input)
    {
        IsAttacking = input.isPressed;
    }
}