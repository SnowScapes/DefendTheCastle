using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public UpgradeList upgradeList;
    [SerializeField]
    private Text attributeTxt;
    [SerializeField] 
    private Text costTxt;
    [SerializeField] 
    private GameObject abiltyGO;
    [SerializeField] 
    private Text currentAbility;
    [SerializeField]
    private Text afterAbility;
    [SerializeField] 
    private GameObject upgradeComplete;
    [SerializeField]
    private Image upgradeImg;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void SetListUI()
    {
        attributeTxt.text = GetType(upgradeList.Type);
        if (upgradeList.UpgradeValues.Length - 1 > upgradeList.UpgradeLv)
        {
            costTxt.text = upgradeList.UpgradeCosts[upgradeList.UpgradeLv].ToString() + " G";
            currentAbility.text = upgradeList.UpgradeValues[upgradeList.UpgradeLv].ToString();
            afterAbility.text = upgradeList.UpgradeValues[upgradeList.UpgradeLv + 1].ToString();
        }
        else
        {
            costTxt.text = " - G";
            abiltyGO.SetActive(false);
            upgradeComplete.SetActive(true);
        }

        upgradeImg = upgradeList.UpgradeImg;
    }

    private string GetType(Define.eUpgradeType type)
    {
        switch(type) 
        {
            case Define.eUpgradeType.PlayerAtk:
                return "플레이어\n공격력";
            case Define.eUpgradeType.PlayerMaxHp:
                return "플레이어\n최대 체력";
            case Define.eUpgradeType.PlayerMoveSpeed:
                return "플레이어\n이동속도";
            case Define.eUpgradeType.CastleLv:
                return "캐슬\n최대 체력";
            default: 
                return string.Empty;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
