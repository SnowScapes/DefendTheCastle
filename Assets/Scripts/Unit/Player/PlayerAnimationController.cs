using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AnimationController
{
    private static readonly int isRun = Animator.StringToHash("isRun");
    private static readonly int isHit = Animator.StringToHash("isHit");
    private static readonly int attackUp = Animator.StringToHash("attackUp"); //���� ����
    private static readonly int attackDiagonalUp = Animator.StringToHash("attackDiagonalUp"); //�缱�� ����
    private static readonly int attackFront = Animator.StringToHash("attackFront"); // �� ����
    private static readonly int attackDiagonalDown = Animator.StringToHash("attackDiagonalDown"); //�缱�Ʒ� ����
    private static readonly int attackDown = Animator.StringToHash("attackDown"); // �Ʒ� ����

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
