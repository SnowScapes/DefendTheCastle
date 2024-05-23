using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private PlayerStat stat;
    [SerializeField]
    private Castle castle;
    [SerializeField]
    private Text currentGoldTxt;
    private Dictionary<Define.eUpgradeType, UpgradeList> dicUpgrade = new Dictionary<Define.eUpgradeType, UpgradeList>();
    public List<UpgradeList> upgradeList = new List<UpgradeList>();
    private List<ShopSlot> slotList = new List<ShopSlot>();
    [SerializeField]
    private UpgradeContentSO[] contentSO;
    
    [SerializeField]
    private ShopSlot upgradePrefab;
    [SerializeField]
    private Text purchasedStateTxt;
    
    void Start()
    {
        stat = GameManager.instance.playerStat;
        currentGoldTxt.text = stat.gold.ToString() + "G ";
        for (int i = 0; i< contentSO.Length; i++) 
        {

            ShopSlot slot = Instantiate(upgradePrefab, transform);
            upgradeList[i].UpgradeImg = slot.upgradeImg;
            upgradeList[i].InitInfo(contentSO[i]);
            dicUpgrade[contentSO[i].type] = upgradeList[i];
            slot.upgradeList = upgradeList[i];
            slot.shop = this;
            slotList.Add(slot);
        }
    }
    
    private void OnEnable()
    {
        if (stat == null)
        {
            stat = GameManager.instance.playerStat;
        }
        currentGoldTxt.text = stat.gold.ToString() + "G ";
    }

    public void OnAtkUpgrade(ShopSlot slot)
    {
        int temp = stat.AtkUpgrade;
        SetValue(Define.eUpgradeType.PlayerAtk, ref temp);
        stat.AtkUpgrade = temp;
        ClearSlotUI(slot);
    }

    public void OnPlayerMaxHpUpgrade(ShopSlot slot)
    {
        int temp = stat.MaxHpUpgrade;
        SetValue(Define.eUpgradeType.PlayerMaxHp, ref temp);
        stat.MaxHpUpgrade = temp;
        ClearSlotUI(slot);
    }

    public void OnCastleUpgrade(ShopSlot slot)
    {
        if (slot.upgradeList.UpgradeCosts.Length != slot.upgradeList.UpgradeLv)
        {
            castle.UpgradeCastle(100);
            stat.gold -= slot.upgradeList.UpgradeCosts[slot.upgradeList.UpgradeLv];
            slot.upgradeList.UpgradeLv++;
        }
        ClearSlotUI(slot);
    }

    public void OnPlayerMoveSpeedUpgrade(ShopSlot slot)
    {
        float temp = stat.moveSpeed;
        SetValue(Define.eUpgradeType.PlayerMoveSpeed, ref temp);
        stat.moveSpeed = temp;
        ClearSlotUI(slot);
    }

    public void OnPlayerAtkPerCountUpgrade(ShopSlot slot)
    {
        int temp = stat.numberOfProjectilesPerShot;
        SetValue(Define.eUpgradeType.PlayerAtkPerCount, ref temp);
        stat.numberOfProjectilesPerShot = temp;
        ClearSlotUI(slot);
    }

    private void ClearSlotUI(ShopSlot slot)
    {
        slot.SetListUI();
        currentGoldTxt.text = stat.gold.ToString() + "G ";
    }

    public void SetValue(Define.eUpgradeType type, ref int value)
    {
        var list = dicUpgrade[type];
        if (!stat.CheckedHaveMoney(list.UpgradeCosts[list.UpgradeLv]))
        {
            OnResult(0);
            return;
        }
        stat.gold -= list.UpgradeCosts[list.UpgradeLv];
        value = list.UpgradeValues[++list.UpgradeLv];
        OnResult(1);
    }
    public void SetValue(Define.eUpgradeType type, ref float value)
    {
        var list = dicUpgrade[type];
        if (!stat.CheckedHaveMoney(list.UpgradeCosts[list.UpgradeLv]))
        {
            OnResult(0);
            return;
        }
        stat.gold -= list.UpgradeCosts[list.UpgradeLv];
        value = list.UpgradeValues[++list.UpgradeLv];
        OnResult(1);
    }

    private void OnResult(int index)
    {
        if (purchasedStateTxt.gameObject.activeSelf)
        {
            StopAllCoroutines();
        }
        StartCoroutine(ActionResult(index));
    }
    IEnumerator ActionResult(int result)
    {
        purchasedStateTxt.gameObject.SetActive(true);
        if (result == 0)
        {
            purchasedStateTxt.text = "업그레이드를 실패하였습니다..";
        }
        else
        {
            purchasedStateTxt.text = "업그레이드에 성공하였습니다..";
        }
        yield return new WaitForSeconds(1.0f);
        purchasedStateTxt.gameObject.SetActive(false);
    }

}
