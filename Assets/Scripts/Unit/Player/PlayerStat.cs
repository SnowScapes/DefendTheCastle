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
    [field:SerializeField] public float size { get; set; }
    [field:SerializeField] public string bulletName { get; set; }
    [field: SerializeField] public float delay { get; set; }
    [field: SerializeField] public float projSpeed { get; set; }
    [field:SerializeField] public float duration { get; set; }
    [field:SerializeField] public float spread { get; set; }
    [field:SerializeField] public int numberOfProjectilesPerShot { get; set; }
    [field:SerializeField] public float multipleProjectilesAngle { get; set; }
    [field:SerializeField] public Color projectileColor { get; set; }
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
        RangedAttackSO _so = so as RangedAttackSO;
        size = _so.size;
        bulletName = _so.bulletName;
        delay = _so.delay;
        duration = _so.duration;
        spread = _so.spread;
        numberOfProjectilesPerShot = _so.numberOfProjectilesPerShot;
        multipleProjectilesAngle = _so.multipleProjectilesAngle;
        projSpeed = _so.projSpeed;
        projectileColor = _so.projectileColor;
        ChangedAtk(_so.power);
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

    public void DamageHandler(int power)
    {
        hp -= power;
        if (hp <= 0)
        {
            // 게임종료
        }
    }
}
