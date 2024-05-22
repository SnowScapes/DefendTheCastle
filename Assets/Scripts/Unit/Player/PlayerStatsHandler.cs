using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerStatsHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerStat stat;
    [SerializeField]
    private Castle castle;

    private void Start()
    {
        stat = GameManager.instance.playerStat;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            int index = item.GetItemType(item.type);
            if (index != -1)
            {
                switch (index)
                {
                    case 0:
                        castle.RepairCastle(item.amount);
                        break;
                    case 1:
                        stat.gold += item.amount;
                        break;
                    case 2:
                        stat.HpRecovery = item.amount;
                        break;
                    case 3:
                        StartCoroutine(stat.FeverTime());
                        break;
                }
                ScoreManager.instance.ItemScoreAdd();
            }
            item.spawner.ReleaseItem(collision.gameObject);
        }
    }

}
