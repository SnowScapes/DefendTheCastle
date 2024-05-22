using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
public enum eSpecialMode {normal, invincibleMode, speedMode}

[System.Serializable]
public class PlayerStat : UnitStat
{
    public Transform front;

    public AttackSO attackSO;
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
            front.localScale = new Vector3((float)hp / maxHp, 1.0f, 1.0f);
            return;
        }
        else
        {
            hp = maxHp;
            front.localScale = Vector3.one;
        }
    }

    private void IncreasedHp(int addValue)
    {
        int temp = addValue - maxHp;
        maxHp = addValue;
        hp += temp;
        front.localScale = new Vector3((float)hp / maxHp, 1.0f, 1.0f);
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
        front.localScale = new Vector3((float)hp / maxHp, 1.0f, 1.0f);
        if (hp <= 0)
        {
            // 게임종료
        }
    }

    public IEnumerator FeverTime()
    {
        float speed = moveSpeed;
        moveSpeed *= 1.5f;
        yield return new WaitForSeconds(3.0f);
        moveSpeed = speed;
    }
}
