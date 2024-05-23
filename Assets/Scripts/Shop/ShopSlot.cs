using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public UpgradeList upgradeList;
    public Shop shop;
    [SerializeField]
    private Button upgradeBtn;  
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
    public Image upgradeImg;

    // Start is called before the first frame update
    void Start()
    {
        SetListUI();
        attributeTxt.text = GetType(upgradeList.Type);
    }

    public void SetListUI()
    {        
        if (upgradeList.UpgradeCosts.Length == upgradeList.UpgradeLv)
        {
            costTxt.text = " - G";
            abiltyGO.SetActive(false);
            upgradeComplete.SetActive(true);
            upgradeBtn.interactable = false;
        }
        else
        {
            costTxt.text = upgradeList.UpgradeCosts[upgradeList.UpgradeLv].ToString() + " G";
            currentAbility.text = upgradeList.UpgradeValues[upgradeList.UpgradeLv].ToString();
            afterAbility.text = upgradeList.UpgradeValues[upgradeList.UpgradeLv + 1].ToString();
        }

        upgradeImg = upgradeList.UpgradeImg;
    }

    private string GetType(Define.eUpgradeType type)
    {
        switch(type) 
        {
            case Define.eUpgradeType.PlayerAtk:
                upgradeBtn.onClick.AddListener(() => shop.OnAtkUpgrade(this));
                return "플레이어\n공격력";
            case Define.eUpgradeType.PlayerMaxHp:
                upgradeBtn.onClick.AddListener(() => shop.OnPlayerMaxHpUpgrade(this));
                return "플레이어\n최대 체력";
            case Define.eUpgradeType.PlayerMoveSpeed:
                upgradeBtn.onClick.AddListener(() => shop.OnPlayerMoveSpeedUpgrade(this));
                return "플레이어\n이동속도";
            case Define.eUpgradeType.PlayerAtkPerCount:
                upgradeBtn.onClick.AddListener(() => shop.OnPlayerAtkPerCountUpgrade(this));
                return "화살\n발사개수";
            case Define.eUpgradeType.CastleLv:
                upgradeBtn.onClick.AddListener(() => shop.OnCastleUpgrade(this));
                return "캐슬\n최대 체력";
            default: 
                return string.Empty;
        }
    }
}
