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
    private static readonly int reverse = Animator.StringToHash("reverse");
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
        if (degree <= 90 && degree >= -90)
            animator.SetBool(reverse, false);
        else
            animator.SetBool(reverse, true);

        if (degree <= 90 && degree >= 67.5 || degree <= 112.5 && degree >= 90) //  상단
            animator.SetTrigger(attackUp);
        else if (degree < 67.5 && degree >= 22.5 || degree <= 157.5 && degree >= 112.5) //  대각 상단
            animator.SetTrigger(attackDiagonalUp);
        else if (degree < 22.5 && degree >= -22.5 || degree <= 180 && degree >= 157.5 || degree >= -180 && degree <= -157.5) //  정면
            animator.SetTrigger(attackFront);
        else if (degree < -22.5 && degree >= -67.5 || degree >= -157.5 && degree <= -112.5) //  대각 하단
            animator.SetTrigger(attackDiagonalDown);
        else if (degree < -67.5 && degree >= -90 || degree >= -112.5 && degree <= -90) //  하단
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
