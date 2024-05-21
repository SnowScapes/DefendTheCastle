
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ItemSpawner : Spawner
{

    public void DropItem(GameObject monster, int amount)
    {
        GameObject go = pools.Get();
        go.transform.position = monster.transform.position;
        int rand = Random.Range(0, (int)Define.eItmeType.MaxCount);
        go.GetComponent<Item>().Init((Define.eItmeType)rand, amount);
    }
}
