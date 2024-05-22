using System;
using UnityEngine;

public class PlayerBehavior : BehaviorController
{
    protected bool IsAttacking { get; set; }
    private float timeSinceLastAttack = float.MaxValue;

    [SerializeField]private PlayerStat stats;
    [SerializeField]private Castle castle;
    [SerializeField]private ParticleSystem ps;
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
        GameManager.instance.playerStat = stats;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            int index = item.GetItemType(item.type);
            if (index != -1)
            {
                switch (index)
                {
                    case 0:
                        castle.RepairCastle(item.amount);
                        break;
                    case 1:
                        stats.gold += item.amount;
                        break;
                    case 2:
                        stats.HpRecovery = item.amount;
                        break;
                    case 3:
                        StartCoroutine(stats.FeverTime(ps));
                        break;
                }
                ScoreManager.instance.ItemScoreAdd();
            }
            item.spawner.ReleaseItem(collision.gameObject);
        }
    }
}