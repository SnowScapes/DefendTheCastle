using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eSpecialMode {normal, invincibleMode, speedMode}

[Serializable]
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
