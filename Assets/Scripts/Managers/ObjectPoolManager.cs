using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{

    public IObjectPool<GameObject> InitPool(GameObject go, int count)
    {
        IObjectPool<GameObject> pool = new ObjectPool<GameObject>(() => CreatePool(go), GetPool, ReleasePool, DestroyPool, defaultCapacity: count, maxSize: 20);       
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

    protected virtual GameObject CreatePool(GameObject pool)
    {
        GameObject go = Instantiate(pool);
        return go;
    }
}
