using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class BehaviorController : MonoBehaviour
{
    public Action<Vector2> OnMoveEvent;
    public Action<Vector2> OnLookEvent;
    public Action<int> OnAttackEvent;
    public Action OnSkillEvent;


    public void CallMoveEvent(Vector2 input)
    {
        OnMoveEvent?.Invoke(input);
    }

    public void CallLookEvent(Vector2 input)
    {
        OnLookEvent?.Invoke(input);
    }

    public void CallAttackEvent(int attack)
    {
        OnAttackEvent?.Invoke(attack);
    }

    public void CallSkillEvent()
    {
        OnSkillEvent?.Invoke();
    }
}
