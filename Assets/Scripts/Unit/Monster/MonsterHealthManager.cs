using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthManager : MonoBehaviour
{
    [SerializeField] private MonsterStat stat;
    private MonsterAnimationController anim;
    public ItemSpawner itemSpawner;
    private MonsterBehavior controller;

    private void Awake()
    {
        controller = GetComponent<MonsterBehavior>();
        stat = controller.stat;
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
            itemSpawner.DropItem(this.gameObject, 100);
            controller.die = true;
            gameObject.SetActive(false);
            ScoreManager.instance.MonsterScoreAdd(this.gameObject.name);
        }
    }
}
