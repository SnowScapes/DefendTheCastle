
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ItemSpawner : Spawner
{
    
    protected override void SetTrans(GameObject go)
    {
        base.SetTrans(go);
        go.GetComponent<Item>().spawner = this;
    }
    public void DropItem(GameObject monster, int amount)
    {
        GameObject go = pools.Get();
        go.transform.position = monster.transform.position;
        int rand = Random.Range(0, (int)Define.eItmeType.MaxCount);
        go.GetComponent<Item>().Init((Define.eItmeType)rand, amount);
    }

}
