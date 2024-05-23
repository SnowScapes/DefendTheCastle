using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStat
{
    [field: SerializeField] public int hp { get; set; }
    [field: SerializeField] public int maxHp { get; set; }
    [field: SerializeField] public int atk { get; set; }
    [field: SerializeField] public float moveSpeed { get; set; }
    [field: SerializeField] public int gold { get; set; } = 0;
}
