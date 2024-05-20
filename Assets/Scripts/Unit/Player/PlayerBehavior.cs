using System;
using UnityEngine;

public class PlayerBehavior : BehaviorController
{
    protected bool IsAttacking { get; set; }
    private float timeSinceLastAttack = float.MaxValue;

    [SerializeField]private PlayerStat stats;

    public PlayerStat Stats
    {
        get { return stats; }
    }

    protected virtual void Awake()
    {
        
    }

    private void Start()
    {
        stats.InitStat(stats.attackSO);
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack <= stats.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if (IsAttacking)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent(stats.atk);
        }
    }
}