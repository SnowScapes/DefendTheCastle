using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitStat : MonoBehaviour
{
    [SerializeField]protected int id;
    [SerializeField]protected string name;
    [SerializeField]protected int maxHp;
    [SerializeField]protected int hp;
    [SerializeField]protected float moveSpeed;
    [SerializeField]protected float attackSpeed;
    [SerializeField]protected int atk;
    [SerializeField]protected float range;
    [SerializeField]protected int level;
    [SerializeField]protected int gold;
}
