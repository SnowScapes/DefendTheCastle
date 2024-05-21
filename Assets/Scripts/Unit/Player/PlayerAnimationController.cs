using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AnimationController
{
    private static readonly int isRun = Animator.StringToHash("isRun");
    private static readonly int isHit = Animator.StringToHash("isHit");
    private static readonly int attackUp = Animator.StringToHash("attackUp"); //위쪽 공격
    private static readonly int attackDiagonalUp = Animator.StringToHash("attackDiagonalUp"); //사선위 공격
    private static readonly int attackFront = Animator.StringToHash("attackFront"); // 옆 공격
    private static readonly int attackDiagonalDown = Animator.StringToHash("attackDiagonalDown"); //사선아래 공격
    private static readonly int attackDown = Animator.StringToHash("attackDown"); // 아래 공격

    private readonly float magnituteThreshold = 0.5f;
    private float degree;
    private void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        controller.OnAttackEvent += Attacking;
        controller.OnMoveEvent += Move;
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
       degree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(isRun, vector.magnitude > magnituteThreshold);
    }

    protected virtual void Attacking(int n)
    {
        if (degree <= 90 && degree >= 60)
            animator.SetTrigger(attackUp);
        else if (degree < 60 && degree >= 30)
            animator.SetTrigger(attackDiagonalUp);
        else if (degree < 30 && degree >= -30)
            animator.SetTrigger(attackFront);
        else if (degree < -30 && degree >= -60)
            animator.SetTrigger(attackDiagonalDown);
        else if (degree < -60 && degree >= -90)
            animator.SetTrigger(attackDown);


    }

    private void Hit()
    {
        animator.SetBool(isHit, true);
    }

    private void InvincibilityEnd()
    {
        animator.SetBool(isHit, false);
    }
}
