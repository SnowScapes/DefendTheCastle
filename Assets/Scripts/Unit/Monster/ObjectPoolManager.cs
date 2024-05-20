using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    public IObjectPool<GameObject> InitPool(GameObject go)
    {
        IObjectPool<GameObject> pool = new ObjectPool<GameObject>(() => CreatePool(go), GetPool, ReleasePool, DestroyPool, maxSize: 20);
        return pool;       
    }

    private void DestroyPool(GameObject pool)
    {
        Destroy(pool);
    }

    private void ReleasePool(GameObject pool)
    {
        pool.SetActive(false);
    }

    public void GetPool(GameObject pool)
    {
        pool.SetActive(true);
    }

    private GameObject CreatePool(GameObject pool)
    {
        GameObject go = Instantiate(pool);
        //TODO 받아넣기
        return go;
    }
}
