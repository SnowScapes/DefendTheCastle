using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : UnitStat
{
    public bool knockback;
    public enum eSpecialMode {invincibleMode, speedMode}
    public int AtkUpgrade { get; private set; }
    public int HpUpgrade { get; private set; }
}
