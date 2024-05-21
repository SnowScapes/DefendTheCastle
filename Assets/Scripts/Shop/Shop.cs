using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private PlayerStat stat;
    [SerializeField]
    private Castle castle;

    private Dictionary<Define.eUpgradeType, UpgradeList> dicUpgrade = new Dictionary<Define.eUpgradeType, UpgradeList>();
    public List<UpgradeList> upgradeList = new List<UpgradeList>();

    [SerializeField]
    private UpgradeContentSO[] contentSO;
    [SerializeField]
    private GameObject upgradePrefab;
    [SerializeField]
    private Text purchasedStateTxt;
    // Start is called before the first frame update
    void Start()
    {
        stat = player.GetComponent<InputController>().Stats;
        for(int i = 0; i< contentSO.Length; i++) 
        {

            GameObject go = Instantiate(upgradePrefab, transform);
            upgradeList[i].InitInfo(contentSO[i]);
            dicUpgrade[contentSO[i].type] = upgradeList[i];
            go.GetComponent<ShopSlot>().upgradeList = upgradeList[i];
            go.GetComponent<ShopSlot>().shop = this;
        }
    }

    public void OnAtkUpgrade()
    {
        int temp = stat.AtkUpgrade;
        SetValue(Define.eUpgradeType.PlayerAtk, ref temp);
        //player.AtkUpgrade = temp;
    }

    public void OnPlayerMaxHpUpgrade()
    {
        int temp = stat.MaxHpUpgrade;
        SetValue(Define.eUpgradeType.PlayerMaxHp, ref temp);
    }

    public void OnCastleUpgrade()
    {
        castle.UpgradeCastle(100);
    }

    public void OnPlayerMoveSpeedUpgrade()
    {
        float temp = stat.moveSpeed;
        SetValue(Define.eUpgradeType.PlayerMoveSpeed, ref temp);
    }

    public void OnPlayerAtkSpeedUpgrade()
    {
        //float temp = player.;
        //SetValue(Define.eUpgradeType.PlayerAtkSpeed, ref temp);
    }

    public void OnSpecialItem()
    {

    }



    public void SetValue(Define.eUpgradeType type, ref int value)
    {
        var list = dicUpgrade[type];
        if (!stat.CheckedHaveMoney(list.UpgradeCosts[list.UpgradeLv]))
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
        if (!stat.CheckedHaveMoney(list.UpgradeCosts[list.UpgradeLv]))
        {
            OnResult(0);
            return;
        }
        value = list.UpgradeValues[list.UpgradeLv];
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
            purchasedStateTxt.text = "업그레이드에 실패하였습니다.";
        }
        else
        {
            purchasedStateTxt.text = "업그레이드를 성공하였습니다.";
        }
        yield return new WaitForSeconds(1.0f);
        purchasedStateTxt.gameObject.SetActive(false);
    }

}
