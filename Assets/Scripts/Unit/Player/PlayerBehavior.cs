using UnityEngine;

public class PlayerBehavior : BehaviorController
{
    protected bool IsAttacking { get; set; }
    private float timeSinceLastAttack = float.MaxValue;

    protected PlayerStatsHandler stats { get; private set; }

    protected virtual void Awake()
    {
        stats = GetComponent<PlayerStatsHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack <= stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if (IsAttacking)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent(stats.CurrentStat.attackSO);
        }
    }
}