using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UpgradeSO", menuName = "Upgrade/Default", order = 0)]
public class UpgradeContentSO : ScriptableObject
{
    public Define.eUpgradeType type;
    public int upgradeLv = 0;
    public int[] upgradeValues;
    public int[] upgradeCosts;
    public Sprite upgradeUI;
}
