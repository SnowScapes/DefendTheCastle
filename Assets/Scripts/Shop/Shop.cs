using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private PlayerStat player;
    [SerializeField]
    private Castle castle;

    private Dictionary<Define.eUpgradeType, UpgradeList> dicUpgrade = new Dictionary<Define.eUpgradeType, UpgradeList>();
    public List<UpgradeList> upgradeList = new List<UpgradeList>();

    [SerializeField]
    private UpgradeContentSO[] contentSO;
    [SerializeField]
    private GameObject upgradePrefab;
    [SerializeField]
    private GameObject[] purchasedAction;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< contentSO.Length; i++) 
        {

            GameObject go = Instantiate(upgradePrefab, transform);
            upgradeList[i].InitInfo(contentSO[i]);
            dicUpgrade[contentSO[i].type] = upgradeList[i];
            go.GetComponent<ShopSlot>().upgradeList = upgradeList[i];
        }
    }

    public void OnAtkUpgrade()
    {
        int temp = player.AtkUpgrade;
        SetValue(Define.eUpgradeType.PlayerAtk, ref temp);
        //player.AtkUpgrade = temp;
    }

    public void OnPlayerMaxHpUpgrade()
    {
        int temp = player.MaxHpUpgrade;
        SetValue(Define.eUpgradeType.PlayerMaxHp, ref temp);
    }

    public void OnCastleUpgrade()
    {
        castle.SetCastleHp(100);
    }

    public void OnPlayerMoveSpeedUpgrade()
    {
        float temp = player.moveSpeed;
        SetValue(Define.eUpgradeType.PlayerMoveSpeed, ref temp);
    }

    public void OnSpecialItem()
    {

    }


    public void SetValue(Define.eUpgradeType type, ref int value)
    {
        var list = dicUpgrade[type];
        if (!player.CheckedHaveMoney(list.UpgradeCosts[list.UpgradeLv]))
        {
            OnResult(0);
            return;
        }
        value = list.UpgradeValues[list.UpgradeLv];
        OnResult(1);
    }
    public void SetValue(Define.eUpgradeType type, ref float value)
    {
        var list = dicUpgrade[type];
        if (!player.CheckedHaveMoney(list.UpgradeCosts[list.UpgradeLv]))
        {
            OnResult(0);
            return;
        }
        value = list.UpgradeValues[list.UpgradeLv];
        OnResult(1);
    }

    private void OnResult(int index)
    {
        if (purchasedAction[0].activeSelf || purchasedAction[1].activeSelf)
        {
            StopAllCoroutines();
            purchasedAction[0].SetActive(false);
            purchasedAction[1].SetActive(false);
        }
        StartCoroutine(ActionResult(index));
    }
    IEnumerator ActionResult(int result)
    {
        purchasedAction[result].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        purchasedAction[result].SetActive(false);
    }

}
