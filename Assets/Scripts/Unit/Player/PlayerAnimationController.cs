using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    private float degree;
    private float speed;
    
    protected override void Awake()
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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (degree <= 90 && degree >= 67.5 || degree <= 112.5 && degree >= 90) //  ���
            animator.SetTrigger(attackUp);
        else if (degree < 67.5 && degree >= 22.5 || degree <= 157.5 && degree >= 112.5) //  �밢 ���
            animator.SetTrigger(attackDiagonalUp);
        else if (degree < 22.5 && degree >= -22.5 || degree <= 180 && degree >= 157.5 || degree >= -180 && degree <= -157.5) //  ����
            animator.SetTrigger(attackFront);
        else if (degree < -22.5 && degree >= -67.5 || degree >= -157.5 && degree <= -112.5) //  �밢 �ϴ�
            animator.SetTrigger(attackDiagonalDown);
        else if (degree < -67.5 && degree >= -90 || degree >= -112.5 && degree <= -90) //  �ϴ�
            animator.SetTrigger(attackDown);
    }
}
