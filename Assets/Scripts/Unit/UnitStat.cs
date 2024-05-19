using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitStat : MonoBehaviour
{
    public int id { get; set; }
    public string unitName { get; set; }
    public int maxHp { get; set; }
    public int hp { get; set; }
    public float moveSpeed { get; set; }
    public float attackSpeed { get; set; }
    public int atk { get; set; }
    public float range { get; set; }
    public int level { get; set; }
    public int gold { get; set; }
}
