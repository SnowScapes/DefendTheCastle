using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthManager : MonoBehaviour
{
    [SerializeField] private MonsterStat stat;

    private void Awake()
    {
        stat = this.GetComponent<MonsterBehavior>().stat;
    }

    private void Start()
    {
        stat.hp = stat.maxHp;
    }

    public void DamageHandler(int power)
    {
        Debug.Log("Damaged");
        stat.hp -= power;
        if (stat.hp <= 0)
        {
            Debug.Log("Monster Die");
        }
    }
}
