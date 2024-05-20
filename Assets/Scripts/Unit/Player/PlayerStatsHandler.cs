using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsHandler : MonoBehaviour
{
    // 기본 스탯과 추가 스탯을 계산해서 최종 스탯을 계산하는 로직

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
        CurrentStat.maxHp = baseStat.maxHp;
        CurrentStat.moveSpeed = baseStat.moveSpeed;

        // Line 20 ~ 32 기본 능력치 적용

    }
}
