using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eSpecialMode {normal, invincibleMode, speedMode}

[Serializable]
public class PlayerStat : UnitStat
{
    public bool knockback;

    public eSpecialMode mode;
    [field: SerializeField]public int AtkUpgrade { get; private set; }
    [field: SerializeField]public int HpUpgrade { get; private set; }
}
