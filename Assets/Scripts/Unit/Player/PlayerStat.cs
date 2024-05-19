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
    // �����ؼ� ��ģ �ڵ�
    public bool knockback;
    public StatsChangeType statsChangeType; // ������ ��� ���ϴ���
    public eSpecialMode mode;
    [field: SerializeField] public int AtkUpgrade { get; private set; }
    [field: SerializeField] public int HpUpgrade { get; private set; }
    public AttackSO attackSO;

    // ���� �ڵ�
    //public StatsChangeType statsChangeType; // ������ ��� ���ϴ���
    //[Range(1, 100)] public int maxHealth;
    //[Range(1f, 20f)] public float speed;
    //public AttackSO attackSO;
}
