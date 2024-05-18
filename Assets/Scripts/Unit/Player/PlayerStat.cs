using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : UnitStat
{
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
    //최대 체력 증가
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
    //체력회복
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
