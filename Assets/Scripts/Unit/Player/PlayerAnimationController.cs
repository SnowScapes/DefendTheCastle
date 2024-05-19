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

    private void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        controller.OnAttackEvent += Attacking;
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(isRun, vector.magnitude > magnituteThreshold);
    }

    private void Attacking()
    {
        animator.SetTrigger(attackFront);
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
