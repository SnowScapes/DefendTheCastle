using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UpgradeList
{
    public Define.eUpgradeType Type;
    public int UpgradeLv = 0;
    public int[] UpgradeValues;
    public int[] UpgradeCosts;
    public Image UpgradeImg;

    public void InitInfo(UpgradeContentSO so)
    {
        Type = so.type;
        UpgradeLv = so.upgradeLv;
        UpgradeValues = so.upgradeValues;
        UpgradeCosts = so.upgradeCosts;
        //UpgradeImg.sprite = so.upgradeUI;
    }
}

