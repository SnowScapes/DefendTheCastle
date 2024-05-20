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
    public StatsChangeType statsChangeType; // 스탯이 어떻게 변하는지
    public AttackSO attackSO;

    public bool knockback;
    public enum eSpecialMode { invincibleMode, speedMode }
    public int AtkUpgrade
    {
        get
        {
            return atk;
        }
        set
        {
            IncreasedAtk(value);
        }
    }

    public int MaxHpUpgrade
    {
        get
        {
            return maxHp;
        }
        set
        {
            IncreasedHp(value);
        }
    }

    public int HpRecovery
    {
        get
        {
            return hp;
        }
        set
        {
            RecoveryHp(value);
        }
    }

    private void IncreasedAtk(int addValue)
    {
        atk += addValue;
    }

    private void RecoveryHp(int addValue)
    {
        if (hp + addValue <= maxHp)
        {
            hp += addValue;
            return;
        }
        else
        {
            hp = maxHp;
        }
    }

    private void IncreasedHp(int addValue)
    {
        maxHp += addValue;
        hp += addValue;
    }


}
