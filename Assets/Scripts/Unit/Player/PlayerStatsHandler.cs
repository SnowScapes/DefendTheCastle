using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsHandler : MonoBehaviour
{
    // �⺻ ���Ȱ� �߰� ������ ����ؼ� ���� ������ ����ϴ� ����

    [SerializeField] private PlayerStat baseStat;
    public PlayerStat CurrentStat { get; private set; }

    public List<PlayerStat> statModifiers = new List<PlayerStat>();

    private void Awake()
    {
        UpdatePlayerStat();
    }

    private void UpdatePlayerStat()
    {
        AttackSO attackSO = null;

        if (baseStat.attackSO != null)
            attackSO = Instantiate(baseStat.attackSO);

        CurrentStat = new PlayerStat { attackSO = attackSO };

        CurrentStat.statsChangeType = baseStat.statsChangeType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed = baseStat.speed;

        // Line 20 ~ 32 �⺻ �ɷ�ġ ����

    }
}
