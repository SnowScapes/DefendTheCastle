using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public IObjectPool<GameObject> pools;

    [SerializeField]
    protected ObjectPoolManager creator;

    [SerializeField]
    protected GameObject[] objPrefab;

    [SerializeField]
    protected GameObject poolBox;

    protected int DefaultItemCount = 5;

    protected virtual void Start()
    {
        FilledPool();
    }

    protected virtual void FilledPool()
    {
        for (int i = 0; i < objPrefab.Length; i++)
        {
            pools = creator.InitPool(objPrefab[i], DefaultItemCount);
            Summon();
        }
    }

    protected void Summon()
    {
        List<GameObject> list = new List<GameObject>();
        list.Capacity = DefaultItemCount;
        for (int i = 0; i < DefaultItemCount; i++)
        {
            GameObject go = pools.Get();
            SetTrans(go);
            list.Add(go);
        }

        for (int i = 0; i < DefaultItemCount; i++)
        {
            pools.Release(list[i]);
        }
    }

    protected void SetTrans(GameObject go)
    {
        go.transform.SetParent(poolBox.transform);
        go.transform.position = poolBox.transform.position;
    }
}
