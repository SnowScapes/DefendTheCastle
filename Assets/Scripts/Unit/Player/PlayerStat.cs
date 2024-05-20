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


[System.Serializable]
public class PlayerStat : UnitStat
{
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
            ChangedAtk(value);
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

    public void InitStat(AttackSO so)
    {
        ChangedAtk(so.power);
    }
    private void ChangedAtk(int addValue)
    {
        atk = addValue;
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
        int temp = addValue - maxHp;
        maxHp = addValue;
        hp += temp;
    }

    public bool CheckedHaveMoney(int cost)
    {
        if (gold >= cost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
