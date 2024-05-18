using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    protected bool IsAttacking { get; set; }
    private float timeSinceLastAttack = float.MaxValue;

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack < 0.2f) // 0,2f -> 수정 필요
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if(IsAttacking)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent();
        }
    }


    public void CallMoveEvent(Vector2 input)
    {
        OnMoveEvent?.Invoke(input);
    }

    public void CallLookEvent(Vector2 input)
    {
        OnLookEvent?.Invoke(input);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
