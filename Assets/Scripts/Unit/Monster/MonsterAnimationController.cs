using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAnimationController : AnimationController
{
    private static readonly int attack = Animator.StringToHash("attack");
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

    private void Attacking(AttackSO attackSo)
    {
        animator.SetTrigger(attack);
    }

    private void MoveAnimation(Vector2 direction)
    {
        if ((Vector2)transform.position != direction)
            animator.SetBool("isRun", true);
        else
            animator.SetBool("isRun", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("isRun", false);
    }
}
