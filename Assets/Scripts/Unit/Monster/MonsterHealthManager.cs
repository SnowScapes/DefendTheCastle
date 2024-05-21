using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthManager : MonoBehaviour
{
    [SerializeField] private MonsterStat stat;
    private MonsterAnimationController anim;

    private void Awake()
    {
        stat = this.GetComponent<MonsterBehavior>().stat;
        anim = GetComponentInChildren<MonsterAnimationController>();
    }

    private void Start()
    {
        stat.hp = stat.maxHp;
    }

    public void DamageHandler(int power)
    {
        stat.hp -= power;
        anim.Hitting();
        if (stat.hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
