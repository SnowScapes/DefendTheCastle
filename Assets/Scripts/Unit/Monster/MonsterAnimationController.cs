using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationController : PlayerAnimationController
{
    private static readonly int attack = Animator.StringToHash("attack");

    private void Awake()
    {
        base.Awake();
    }

    protected override void Attacking()
    {
        animator.SetTrigger(attack);
    }
}
