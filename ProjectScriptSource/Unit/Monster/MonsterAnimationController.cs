using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAnimationController : AnimationController
{
    private Transform _transform;
    private MonsterBehavior _monsterBehavior;

    protected override void Awake()
    {
        base.Awake();
        _transform = GetComponent<Transform>();
        _monsterBehavior = GetComponent<MonsterBehavior>();
    }

    private void Start()
    {
        controller.OnAttackEvent += Attacking;
        controller.OnMoveEvent += MoveAnimation;
    }

    private void Attacking(int _)
    {
        animator.SetTrigger("attack");
    }

    private void MoveAnimation(Vector2 direction)
    {
        animator.SetTrigger("run");
    }

    public void Hitting()
    {
        animator.SetTrigger("hit");
    }
}
