using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthManager : MonoBehaviour
{
    [SerializeField] private MonsterStat stat;

    private void Awake()
    {
        stat = this.GetComponent<MonsterStat>();
    }

    private void Start()
    {
        stat.hp = stat.maxHp;
    }

    public void DamageHandler(AttackSO attackSO)
    {
        stat.hp -= (int)attackSO.power;
        if (stat.hp <= 0)
        {
            Debug.Log("Monster Die");
        }
    }
}
