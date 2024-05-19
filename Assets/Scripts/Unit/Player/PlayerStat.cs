using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eSpecialMode {normal, invincibleMode, speedMode}
public enum StatsChangeType
{
    Add,
    Multiple,
    Override
}


[Serializable]
public class PlayerStat : UnitStat
{
    // 머지해서 합친 코드
    public bool knockback;
    public StatsChangeType statsChangeType; // 스탯이 어떻게 변하는지
    public eSpecialMode mode;
    [field: SerializeField] public int AtkUpgrade { get; private set; }
    [field: SerializeField] public int HpUpgrade { get; private set; }
    public AttackSO attackSO;

    // 기존 코드
    //public StatsChangeType statsChangeType; // 스탯이 어떻게 변하는지
    //[Range(1, 100)] public int maxHealth;
    //[Range(1f, 20f)] public float speed;
    //public AttackSO attackSO;
}
