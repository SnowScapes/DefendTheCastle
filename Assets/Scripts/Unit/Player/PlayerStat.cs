using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override
}

[System.Serializable]
public class PlayerStat
{
    //public bool knockback;
    //public enum eSpecialMode {invincibleMode, speedMode}
    //public int AtkUpgrade { get; private set; }
    //public int HpUpgrade { get; private set; }

    public StatsChangeType statsChangeType; // 스탯이 어떻게 변하는지
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
}
