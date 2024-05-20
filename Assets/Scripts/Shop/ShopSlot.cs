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
    [SerializeField]
    private Image upgradeImg;

    // Start is called before the first frame update
    void Start()
    {
        SetListUI();
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
                upgradeBtn.onClick.AddListener(shop.OnAtkUpgrade);
                return "�÷��̾�\n���ݷ�";
            case Define.eUpgradeType.PlayerMaxHp:
                upgradeBtn.onClick.AddListener(shop.OnPlayerMaxHpUpgrade);
                return "�÷��̾�\n�ִ� ü��";
            case Define.eUpgradeType.PlayerMoveSpeed:
                upgradeBtn.onClick.AddListener(shop.OnPlayerMoveSpeedUpgrade);
                return "�÷��̾�\n�̵��ӵ�";
            case Define.eUpgradeType.PlayerAtkSpeed:
                upgradeBtn.onClick.AddListener(shop.OnPlayerAtkSpeedUpgrade);
                return "�÷��̾�\n���ݼӵ�";
            case Define.eUpgradeType.CastleLv:
                upgradeBtn.onClick.AddListener(shop.OnCastleUpgrade);
                return "ĳ��\n�ִ� ü��";
            default: 
                return string.Empty;
        }
    }
}
